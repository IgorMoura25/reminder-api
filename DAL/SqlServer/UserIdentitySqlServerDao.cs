using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.IdentityDAL.Services;
using IgorMoura.IdentityDAL.Entities;
using IgorMoura.Reminder.Extensions.Exceptions;


namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class UserIdentitySqlServerDao : IUserDao
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private IdentityEmailService _identityEmailService { get; set; }

        public UserIdentitySqlServerDao(UserManager<IdentityUser> userManager, IdentityEmailService identityEmailService)
        {
            _userManager = userManager;
            _identityEmailService = identityEmailService;
        }

        public async Task<long> AddAsync(AddUserRequestModel model)
        {
            var identityUser = await _userManager.FindByEmailAsync(model.Email);

            if (identityUser != null)
            {
                throw new UserAlreadyExistException();
            }

            var identityResult = await _userManager.CreateAsync(new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            }, model.Password);

            if (!identityResult.Succeeded)
            {
                if (identityResult.Errors.Any(x => x.Code.StartsWith("InternalError")))
                {
                    throw new IdentityOperationException()
                    {
                        IdentityResultErrors = identityResult.Errors.ToList().ConvertAll(x => new IdentityResultError()
                        {
                            Code = x.Code,
                            Description = x.Description
                        })
                    };
                }

                throw new InvalidIdentityOperationException()
                {
                    IdentityResultErrors = identityResult.Errors.ToList().ConvertAll(x => new IdentityResultError()
                    {
                        Code = x.Code,
                        Description = x.Description
                    })
                };
            }

            identityUser = await _userManager.FindByNameAsync(model.UserName);

            await SendConfirmationEmailToUserAsync(identityUser);

            return Convert.ToInt64(identityUser.Id);
        }

        public async Task<bool> ConfirmUserEmailAsync(ConfirmUserEmailRequestModel model)
        {
            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            var confirmationResult = await _userManager.ConfirmEmailAsync(identityUser, model.Token);

            if (!confirmationResult.Succeeded)
            {
                throw new InvalidIdentityOperationException()
                {
                    IdentityResultErrors = confirmationResult.Errors.ToList().ConvertAll(x => new IdentityResultError()
                    {
                        Code = x.Code,
                        Description = x.Description
                    })
                };
            }

            return confirmationResult.Succeeded;
        }

        private async Task SendConfirmationEmailToUserAsync(IdentityUser identityUser)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);

            await _identityEmailService.SendEmailAsync(new IdentityEmailEntity
            {
                Subject = "Reminder - Email confirmation",
                Destination = identityUser.Email,
                Body = $"Welcome to Reminder! Please use the token below to confirm your email in our API. \n\n\n {token}"
            });
        }
    }
}

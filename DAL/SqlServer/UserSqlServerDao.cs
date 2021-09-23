using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.IdentityDAL.Services;
using IgorMoura.IdentityDAL.Entities;
using System.Text;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class UserSqlServerDao : IUserDao
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private IdentityEmailService _identityEmailService { get; set; }

        public UserSqlServerDao(UserManager<IdentityUser> userManager, IdentityEmailService identityEmailService)
        {
            _userManager = userManager;
            _identityEmailService = identityEmailService;
        }

        public async Task<string> AddAsync(AddUserRequestModel model)
        {
            //TODO: Tratar erro corretamente
            string userId = null;

            var identityUser = await _userManager.FindByEmailAsync(model.Email);

            if (identityUser != null)
            {
                return userId;
            }

            var identityResult = await _userManager.CreateAsync(new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            }, model.Password);

            if (identityResult.Succeeded)
            {
                identityUser = await _userManager.FindByNameAsync(model.UserName);

                await SendConfirmationEmailToUserAsync(identityUser);

                userId = identityUser.Id;
            }

            return userId;
        }

        public async Task<bool> ConfirmUserEmailAsync(ConfirmUserEmailRequestModel model)
        {
            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            //byte[] tokenBytes = Convert.FromBase64String(model.Token);

            //var confirmationResult = await _userManager.ConfirmEmailAsync(identityUser, BitConverter.ToString(tokenBytes));

            var confirmationResult = await _userManager.ConfirmEmailAsync(identityUser, model.Token);

            return true;
        }

        private async Task SendConfirmationEmailToUserAsync(IdentityUser identityUser)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);

            //byte[] byteToken = Encoding.ASCII.GetBytes(token);
            //string base64Token = Convert.ToBase64String(byteToken);

            await _identityEmailService.SendEmailAsync(new IdentityEmailEntity
            {
                Subject = "Reminder - Email confirmation",
                Destination = identityUser.Email,
                Body = $"Welcome to Reminder! Please use the token below to confirm your email in our API. \n\n\n {token}"
            });
        }
    }
}

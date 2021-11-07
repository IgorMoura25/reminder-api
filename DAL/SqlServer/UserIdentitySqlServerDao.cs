using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Extensions.ResultCode.User;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class UserIdentitySqlServerDao : IUserDao
    {
        private UserManager<IdentityUser> _userManager { get; set; }

        public UserIdentitySqlServerDao(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<DataResult<UserEntity>> GetByEmailAsync(string email)
        {
            var identityUser = await _userManager.FindByEmailAsync(email);

            if (identityUser == null)
            {
                return DataResultBuilder<UserEntity>.Error(new UserResultCode().UserNotFound);
            }

            var user = new UserEntity()
            {
                UserId = Convert.ToInt64(identityUser.Id),
                UserName = identityUser.UserName,
                Email = identityUser.Email
            };

            return DataResultBuilder<UserEntity>.Success(user);
        }

        public async Task<DataResult<UserEntity>> GetByNameAsync(string username)
        {
            var identityUser = await _userManager.FindByNameAsync(username);

            if (identityUser == null)
            {
                return DataResultBuilder<UserEntity>.Error(new UserResultCode().UserNotFound);
            }

            var user = new UserEntity()
            {
                UserId = Convert.ToInt64(identityUser.Id),
                UserName = identityUser.UserName,
                Email = identityUser.Email
            };

            return DataResultBuilder<UserEntity>.Success(user);
        }

        public async Task<DataResult<long>> AddAsync(AddUserRequestModel model)
        {
            var identityResult = await _userManager.CreateAsync(new IdentityUser()
            {
                UserName = model.UserName,
                Email = model.Email
            }, model.Password);

            if (!identityResult.Succeeded)
            {
                return DataResultBuilder<long>.Errors(new UserResultCode().AddOperationError, identityResult.Errors?.ToList().ConvertAll(x => new DataResultError()
                {
                    Code = x.Code,
                    Description = x.Description
                }));
            }

            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            return DataResultBuilder<long>.Success(Convert.ToInt64(identityUser.Id));
        }

        public async Task<DataResult<bool>> ConfirmUserEmailAsync(ConfirmUserEmailRequestModel model)
        {
            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            if (identityUser == null)
            {
                return DataResultBuilder<bool>.Error(new UserResultCode().UserNotFound);
            }

            var identityResult = await _userManager.ConfirmEmailAsync(identityUser, model.Token);

            if (!identityResult.Succeeded)
            {
                return DataResultBuilder<bool>.Errors(new UserResultCode().ConfirmEmailOperationError, identityResult.Errors?.ToList().ConvertAll(x => new DataResultError()
                {
                    Code = x.Code,
                    Description = x.Description
                }));
            }

            return DataResultBuilder<bool>.Success(true);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user)
        {
            var identityUser = await _userManager.FindByNameAsync(user.UserName);

            return await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
        }

        public async Task<DataResult<bool>> CheckPasswordAsync(CheckPasswordRequestModel model)
        {
            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            if (identityUser == null)
            {
                return DataResultBuilder<bool>.Error(new UserResultCode().UserNotFound);
            }

            var identityResult = await _userManager.CheckPasswordAsync(identityUser, model.Password);

            if (!identityResult)
            {
                return DataResultBuilder<bool>.Error(new UserResultCode().IncorrectPassword);
            }

            return DataResultBuilder<bool>.Success(true);
        }
    }
}

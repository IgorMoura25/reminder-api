﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.Auth;
using IgorMoura.Reminder.Extensions.ResultCode.Auth;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class AuthIdentitySqlServerDao : IAuthDao
    {
        private UserManager<IdentityUser> _userManager { get; set; }
        private SignInManager<IdentityUser> _signInManager { get; set; }

        public AuthIdentitySqlServerDao(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<DataResult<bool>> SignInAsync(SignInRequestModel model)
        {
            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            if (identityUser == null)
            {
                return DataResultBuilder<bool>.Error(new AuthResultCode().UserOrPasswordIncorrect);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(identityUser, model.Password, false, false);

            if (!signInResult.Succeeded)
            {
                return DataResultBuilder<bool>.Error(new AuthResultCode().UserOrPasswordIncorrect);
            }

            return DataResultBuilder<bool>.Success(true);
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
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

            var signInResult = await _signInManager.PasswordSignInAsync(identityUser, model.Password, false, true);

            if (!signInResult.Succeeded && !signInResult.IsLockedOut)
            {
                return DataResultBuilder<bool>.Error(new AuthResultCode().UserOrPasswordIncorrect);
            }

            if (!signInResult.Succeeded && signInResult.IsLockedOut)
            {
                return DataResultBuilder<bool>.Error(new AuthResultCode().UserLockedOut);
            }

            return DataResultBuilder<bool>.Success(true);
        }

        public async Task<DataResult<string>> GeneratePasswordRedefinitionTokenAsync(GeneratePasswordRedefinitionTokenRequestModel model)
        {
            var identityUser = await _userManager.FindByEmailAsync(model.Email);

            if (identityUser == null)
            {
                return DataResultBuilder<string>.Success(null);
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);

            return DataResultBuilder<string>.Success(token);
        }

        public async Task<DataResult<bool>> ResetPasswordAsync(ResetPasswordRequestModel model)
        {
            var identityUser = await _userManager.FindByNameAsync(model.UserName);

            if (identityUser == null)
            {
                return DataResultBuilder<bool>.Error(new AuthResultCode().UserOrPasswordIncorrect);
            }

            var identityResult = await _userManager.ResetPasswordAsync(identityUser, model.Token, model.NewPassword);

            if (!identityResult.Succeeded)
            {
                return DataResultBuilder<bool>.Errors(new AuthResultCode().ResetPasswordOperationError, identityResult.Errors?.ToList().ConvertAll(x => new DataResultError()
                {
                    Code = x.Code,
                    Description = x.Description
                }));
            }

            return DataResultBuilder<bool>.Success(identityResult.Succeeded);
        }
    }
}

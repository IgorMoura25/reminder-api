using System.Linq;
using System.Threading.Tasks;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Extensions.ResultCode;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Models.DataObjects.Auth;
using IgorMoura.Reminder.Extensions.ResultCode.Auth;
using IgorMoura.Reminder.Models.DataObjects.User;

namespace IgorMoura.Reminder.Services.Handlers
{
    public class AuthHandler : IAuthHandler
    {
        private IAuthDao _authDao { get; }
        private IUserDao _userDao { get; }

        public AuthHandler(IAuthDao authDao, IUserDao userDao)
        {
            _authDao = authDao;
            _userDao = userDao;
        }

        public async Task<ServiceResult<bool>> SignInAsync(SignInEntity model)
        {
            var user = await _userDao.GetByNameAsync(model.UserName);

            if (!user.Succeeded)
            {
                return ServiceResultBuilder<bool>.Error(user.Result);
            }

            if (!user.Data.EmailConfirmed)
            {
                return ServiceResultBuilder<bool>.Error(new AuthResultCode().EmailNotConfirmed);
            }

            var dataResult = await _authDao.SignInAsync(new SignInRequestModel()
            {
                UserName = model.UserName,
                Password = model.Password
            });

            if (!dataResult.Succeeded)
            {
                if (dataResult.Result.Code == new AuthResultCode().UserLockedOut.Code)
                {
                    var passwordResult = await _userDao.CheckPasswordAsync(new CheckPasswordRequestModel()
                    {
                        UserName = model.UserName,
                        Password = model.Password
                    });

                    if (passwordResult.Succeeded)
                    {
                        var error = dataResult.Result;

                        error.Errors = dataResult.Errors?.ToList().ConvertAll(x => new ResultError()
                        {
                            Code = x.Code,
                            Description = x.Description
                        });

                        return ServiceResultBuilder<bool>.Error(error);
                    }
                }

                return ServiceResultBuilder<bool>.Error(new AuthResultCode().UserOrPasswordIncorrect);
            }

            return ServiceResultBuilder<bool>.Success(true);
        }
    }
}

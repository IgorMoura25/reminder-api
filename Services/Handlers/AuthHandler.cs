using System.Linq;
using System.Threading.Tasks;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Extensions.ResultCode;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Models.DataObjects.Auth;

namespace IgorMoura.Reminder.Services.Handlers
{
    public class AuthHandler : IAuthHandler
    {
        private IAuthDao _authDao { get; }

        public AuthHandler(IAuthDao authDao)
        {
            _authDao = authDao;
        }

        public async Task<ServiceResult<bool>> SignInAsync(SignInEntity model)
        {
            var dataResult = await _authDao.SignInAsync(new SignInRequestModel()
            {
                UserName = model.UserName,
                Password = model.Password
            });

            if (!dataResult.Succeeded)
            {
                var error = dataResult.Result;

                error.Errors = dataResult.Errors?.ToList().ConvertAll(x => new ResultError()
                {
                    Code = x.Code,
                    Description = x.Description
                });

                return ServiceResultBuilder<bool>.Error(error);
            }

            return ServiceResultBuilder<bool>.Success(true);
        }
    }
}

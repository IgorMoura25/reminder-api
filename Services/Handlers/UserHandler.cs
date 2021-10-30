using System;
using System.Linq;
using System.Threading.Tasks;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.Reminder.Extensions.ResultCode;
using IgorMoura.Reminder.Extensions.ResultCode.User;

namespace IgorMoura.Reminder.Services.Handlers
{
    public class UserHandler : IUserHandler
    {
        private IUserDao _userDao { get; }
        private EmailHandler _emailHandler { get; set; }

        public UserHandler(IUserDao userDao, EmailHandler emailHandler)
        {
            _userDao = userDao;
            _emailHandler = emailHandler;
        }

        public async Task<ServiceResult<UserEntity>> FindUserByEmailAsync(string email)
        {
            var identityUser = await _userDao.GetByEmailAsync(email);

            if (!identityUser.Succeeded)
            {
                return ServiceResultBuilder<UserEntity>.Error(identityUser.Result);
            }

            var data = new UserEntity()
            {
                Email = identityUser.Data.Email,
                UserName = identityUser.Data.UserName
            };

            return ServiceResultBuilder<UserEntity>.Success(data);
        }

        public async Task<ServiceResult<long>> AddUserAsync(UserEntity user)
        {
            var storedUser = await _userDao.GetByEmailAsync(user.Email);

            if (storedUser.Succeeded && storedUser.Data != null)
            {
                return ServiceResultBuilder<long>.Error(new UserResultCode().UserAlreadyExist);
            }

            var dataResult = await _userDao.AddAsync(new AddUserRequestModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            });

            if (!dataResult.Succeeded)
            {
                var error = dataResult.Result;

                error.Errors = dataResult.Errors?.ToList().ConvertAll(x => new ResultError()
                {
                    Code = x.Code,
                    Description = x.Description
                });

                return ServiceResultBuilder<long>.Error(error);
            }

            var addedUser = await _userDao.GetByNameAsync(user.UserName);

            await SendConfirmationEmailToUserAsync(addedUser.Data);

            return ServiceResultBuilder<long>.Success(Convert.ToInt64(addedUser.Data.UserId));
        }

        public async Task<ServiceResult<bool>> ConfirmUserEmailAsync(EmailConfirmationEntity model)
        {
            var dataResult = await _userDao.ConfirmUserEmailAsync(new ConfirmUserEmailRequestModel()
            {
                UserName = model.UserName,
                Token = model.Token
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

        private async Task SendConfirmationEmailToUserAsync(UserEntity user)
        {
            var token = await _userDao.GenerateEmailConfirmationTokenAsync(user);

            await _emailHandler.SendEmailAsync(new EmailEntity
            {
                Subject = "Reminder - Email confirmation",
                Destination = user.Email,
                Body = $"Welcome to Reminder! Please use the token below to confirm your email in our API. \n\n\n {token}"
            });
        }
    }
}

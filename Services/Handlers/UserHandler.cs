using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Models.DataObjects.User;

namespace IgorMoura.Reminder.Services.Handlers
{
    public class UserHandler : IUserHandler
    {
        private IUserDao _userDao { get; }

        public UserHandler(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public long AddUser(UserEntity user)
        {
            var response = _userDao.Add(new AddUserRequestModel()
            {
                UserName = user.UserName,
                Password = user.Password
            });

            return response;
        }
    }
}

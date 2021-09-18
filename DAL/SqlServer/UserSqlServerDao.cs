using System;
using Microsoft.AspNet.Identity;
using IgorMoura.IdentityDAL.Entities;
using IgorMoura.IdentityDAL.Stores;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class UserSqlServerDao : IUserDao
    {
        private UserStore _userStore { get; }

        public UserSqlServerDao(UserStore userStore)
        {
            _userStore = userStore;
        }

        public long Add(AddDataRequestModel requestModel)
        {
            var model = (AddUserRequestModel)requestModel;

            var userManager = new UserManager<IdentityUser, string>(_userStore);

            var identityResult = userManager.Create(new IdentityUser()
            {
                UserName = model.UserName
            });

            if (!identityResult.Succeeded)
            {
                //TODO: Tratar corretamente o erro
                return 0;
            }

            var user = userManager.FindByName(model.UserName);

            return Convert.ToInt64(user.Id);
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class UserSqlServerDao : IUserDao
    {
        private UserManager<IdentityUser> _userManager { get; set; }

        public UserSqlServerDao(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> AddAsync(AddDataRequestModel requestModel)
        {
            var model = (AddUserRequestModel)requestModel;

            var identityResult = await _userManager.CreateAsync(new IdentityUser()
            {
                UserName = model.UserName
            });

            //TODO: Tratar erro corretamente
            string userId = null;

            if (identityResult.Succeeded)
            {
                var identityUser = await _userManager.FindByNameAsync(model.UserName);

                userId = identityUser.Id;
            }

            return userId;
        }
    }
}

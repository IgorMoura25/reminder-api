using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.User;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class UserSqlServerDao : IUserDao
    {
        private UserManager<IdentityUser> _userManager { get; set; }

        public UserSqlServerDao(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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

                userId = identityUser.Id;
            }

            return userId;
        }
    }
}

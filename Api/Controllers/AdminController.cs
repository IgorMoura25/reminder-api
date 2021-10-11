using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        #region Handlers
        private IUserHandler _userHandler { get; }
        #endregion

        #region Constructors
        public AdminController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        #endregion

        [HttpPost]
        [Route("user")]
        public async Task<string> AddUserAsync([FromBody] UserEntity user)
        {
            return await _userHandler.AddUserAsync(user);
        }

        [HttpPost]
        [Route("user/confirmation")]
        public async Task<bool> ConfirmUserEmailAsync([FromBody] EmailConfirmationEntity user)
        {
            return await _userHandler.ConfirmUserEmailAsync(user);
        }
    }
}

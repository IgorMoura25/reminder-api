using Microsoft.AspNetCore.Mvc;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
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
        [Route("admin/user")]
        public long AddUser([FromBody] UserEntity user)
        {
            return _userHandler.AddUser(user);
        }
    }
}

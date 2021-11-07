using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IgorMoura.Reminder.Api.Utilities;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Models.DataObjects.User;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    [Authorize()]
    [Route("admin")]
    public partial class AdminController : ControllerBase
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
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserApiRequestModel user)
        {
            var response = await _userHandler.AddUserAsync(new UserEntity()
            {
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password
            });

            if (!response.Succeeded)
            {
                var errors = ErrorHandler.HandleUserErrors<long>(response.Result);

                return StatusCode((int)errors.StatusCode, errors);
            }

            var result = new ApiResult<long>(HttpStatusCode.Created, response.Data);

            return StatusCode((int)result.StatusCode, result);
        }

        [HttpPost]
        [Route("user/confirmation")]
        public async Task<IActionResult> ConfirmUserEmailAsync([FromBody] EmailConfirmationEntity user)
        {
            var response = await _userHandler.ConfirmUserEmailAsync(user);

            if (!response.Succeeded)
            {
                var errors = ErrorHandler.HandleUserErrors<long>(response.Result);

                return StatusCode((int)errors.StatusCode, errors);
            }

            var result = new ApiResult<bool>(HttpStatusCode.OK, response.Data);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}

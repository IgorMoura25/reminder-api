﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IgorMoura.Reminder.Api.Utilities;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
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
        public async Task<IActionResult> AddUserAsync([FromBody] UserEntity user)
        {
            try
            {
                var userId = await _userHandler.AddUserAsync(user);

                var result = new ApiResult<string>(HttpStatusCode.Created, userId);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var result = ExceptionHandler.HandleUserErrors<string>(ex);

                return StatusCode((int)result.StatusCode, result);
            }
        }

        [HttpPost]
        [Route("user/confirmation")]
        public async Task<IActionResult> ConfirmUserEmailAsync([FromBody] EmailConfirmationEntity user)
        {
            try
            {
                var isSuccess = await _userHandler.ConfirmUserEmailAsync(user);

                var result = new ApiResult<bool>(HttpStatusCode.OK, isSuccess);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var result = ExceptionHandler.HandleUserErrors<bool>(ex);

                return StatusCode((int)result.StatusCode, result);
            }
        }
    }
}
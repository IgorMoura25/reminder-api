using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using IgorMoura.Reminder.Api.Utilities;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Services.Interfaces;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    public class ReminderController : ControllerBase
    {
        #region Handlers
        private IReminderHandler _reminderHandler { get; }
        #endregion

        #region Constructors
        public ReminderController(IReminderHandler reminderHandler)
        {
            _reminderHandler = reminderHandler;
        }
        #endregion

        [HttpGet]
        [Route("reminder/{reminderId}")]
        public IActionResult GetReminderById(long reminderId)
        {
            try
            {
                var reminder = _reminderHandler.GetReminderById(reminderId);

                var result = new ApiResult<ReminderEntity>(HttpStatusCode.OK, reminder);

                return StatusCode((int)result.StatusCode, result);
            }
            catch (Exception ex)
            {
                var result = ExceptionHandler.HandleReminderErrors<ReminderEntity>(ex);

                return StatusCode((int)result.StatusCode, result);
            }
        }
    }
}
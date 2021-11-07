using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IgorMoura.Reminder.Api.Utilities;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Services.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.Reminder;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    [Authorize()]
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
            var reminder = _reminderHandler.GetReminderById(new GetReminderByIdRequestModel()
            {
                ReminderId = reminderId
            });

            if (!reminder.Succeeded)
            {
                var errors = ErrorHandler.HandleReminderErrors<ReminderEntity>(reminder.Result);

                return StatusCode((int)errors.StatusCode, errors);
            }

            var data = new ReminderEntity()
            {
                ReminderId = reminder.Data.ReminderId,
                ReminderStatusId = reminder.Data.ReminderStatusId,
                Deadline = reminder.Data.Deadline,
                IsActive = reminder.Data.IsActive,
                CreatedAt = reminder.Data.CreatedAt,
                CreatedBy = reminder.Data.CreatedBy
            };

            var result = new ApiResult<ReminderEntity>(HttpStatusCode.OK, data);

            return StatusCode((int)result.StatusCode, result);
        }
    }
}
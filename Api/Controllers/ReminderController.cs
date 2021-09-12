using IgorMoura.Reminder.Services.Handlers;
using IgorMoura.Reminder.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IgorMoura.Reminder.Api.Controllers
{
    [ApiController]
    [Route("reminder")]
    public class ReminderController : ControllerBase
    {
        #region Handlers
        private ReminderHandler _reminderHandler { get; }
        #endregion

        #region Constructors
        public ReminderController(ReminderHandler reminderHandler)
        {
            _reminderHandler = reminderHandler;
        }
        #endregion

        [HttpGet]
        [Route("{reminderId}")]
        public ReminderEntity GetReminderById(long reminderId)
        {
            return _reminderHandler.GetReminderById(reminderId);
        }
    }
}
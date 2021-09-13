using Microsoft.AspNetCore.Mvc;
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
        public ReminderEntity GetReminderById(long reminderId)
        {
            return _reminderHandler.GetReminderById(reminderId);
        }
    }
}
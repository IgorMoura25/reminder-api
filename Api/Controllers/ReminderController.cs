using Microsoft.AspNetCore.Mvc;
using Reminder.Business.Handlers;
using Reminder.Models.Entities;

namespace Reminder.Api.Controllers
{
    [ApiController]
    [Route("reminder")]
    public class ReminderController : ControllerBase
    {
        [HttpGet]
        [Route("{reminderId}")]
        public ReminderEntity GetReminderById(long reminderId)
        {
            return new ReminderHandler().GetReminderById(reminderId);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Reminder.Models;

namespace Reminder.Api.Controllers
{
    [ApiController]
    [Route("reminder")]
    public class ReminderController : ControllerBase
    {
        [HttpGet]
        [Route("{reminderId}")]
        public ReminderDataObject GetProductVersion(long reminderId)
        {
            return new Business.Entities.Reminder().GetReminderById(reminderId);
        }
    }
}
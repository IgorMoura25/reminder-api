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
        public ReminderEntity GetProductVersion(long reminderId)
        {
            return new ReminderHandler().GetReminderById(reminderId);
        }
    }
}
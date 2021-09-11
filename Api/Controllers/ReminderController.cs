using IgorMoura.Reminder.Business.Handlers;
using IgorMoura.Reminder.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IgorMoura.Reminder.Api.Controllers
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
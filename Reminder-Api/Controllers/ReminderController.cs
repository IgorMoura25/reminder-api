using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Reminder_Api.Controllers
{
    [ApiController]
    [Route("reminder")]
    public class ReminderController : ControllerBase
    {
        [HttpGet]
        [Route("{reminderId}")]
        public ReminderDataObject GetProductVersion(long reminderId)
        {
            return new Reminder().GetReminderById(reminderId);
        }
    }
}
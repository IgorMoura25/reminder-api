using System;
using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.Models.DataObjects.Reminder
{
    public class GetReminderByIdRequestModel : GetDataRequestModel
    {
        public long ReminderId { get; set; }
    }
}

using Util.Models;

namespace Reminder.Models.DataObjects.Reminder
{
    public class GetReminderByIdRequestModel : DataRequestModel
    {
        public long ReminderId { get; set; }
    }
}

using Util.Models;

namespace IgorMoura.Reminder.Models.DataObjects.Reminder
{
    public class GetReminderByIdRequestModel : DataRequestModel
    {
        public long ReminderId { get; set; }
    }
}

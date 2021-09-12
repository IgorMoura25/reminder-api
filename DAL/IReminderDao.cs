using IgorMoura.Reminder.Models.DataObjects.Reminder;

namespace IgorMoura.Reminder.DAL
{
    public interface IReminderDao
    {
        public GetReminderByIdResponseModel GetReminderById(GetReminderByIdRequestModel model);
    }
}

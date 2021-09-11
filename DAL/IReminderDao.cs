using Reminder.Models.DataObjects.Reminder;

namespace DAL
{
    public interface IReminderDao
    {
        public GetReminderByIdResponseModel GetReminderById(GetReminderByIdRequestModel model);
    }
}

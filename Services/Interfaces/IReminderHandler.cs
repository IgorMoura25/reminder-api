using IgorMoura.Reminder.Models.DataObjects.Reminder;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IReminderHandler
    {
        public ServiceResult<ReminderEntity> GetReminderById(GetReminderByIdRequestModel model);
    }
}

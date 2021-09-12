using IgorMoura.Reminder.Models.Entities;

namespace Reminder.Services.Interfaces
{
    public interface IReminderHandler
    {
        public ReminderEntity GetReminderById(long reminderId);
    }
}

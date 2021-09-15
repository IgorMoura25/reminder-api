using IgorMoura.Reminder.Models.DataObjects.Reminder;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface IReminderDao : ISingleQuery<GetReminderByIdResponseModel>
    {
    }
}

using IgorMoura.Reminder.DAL.Interfaces.Base;
using IgorMoura.Reminder.Models.DataObjects.Reminder;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface IReminderDao : IQuery<GetReminderByIdResponseModel, GetReminderByIdRequestModel>
    {
    }
}

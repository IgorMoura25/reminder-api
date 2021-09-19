using IgorMoura.Reminder.DAL.Interfaces.Base;
using IgorMoura.Reminder.Models.DataObjects.User;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface IUserDao : ICommandAsync<AddUserRequestModel>
    {
    }
}

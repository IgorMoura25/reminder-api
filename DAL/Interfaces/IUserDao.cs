using System.Threading.Tasks;
using IgorMoura.Reminder.DAL.Interfaces.Base;
using IgorMoura.Reminder.Models.DataObjects.User;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface IUserDao : ICommandAsync<AddUserRequestModel>
    {
        public Task<bool> ConfirmUserEmailAsync(ConfirmUserEmailRequestModel model);
    }
}

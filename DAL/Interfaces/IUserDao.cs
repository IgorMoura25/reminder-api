using System.Threading.Tasks;
using IgorMoura.Reminder.DAL.Interfaces.Base;
using IgorMoura.Reminder.Models.DataObjects.User;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface IUserDao : ICommandAsync<AddUserRequestModel>
    {
        public Task<DataResult<UserEntity>> GetByEmailAsync(string email);
        public Task<DataResult<UserEntity>> GetByNameAsync(string userName);
        public Task<DataResult<bool>> ConfirmUserEmailAsync(ConfirmUserEmailRequestModel model);
        public Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user);
    }
}

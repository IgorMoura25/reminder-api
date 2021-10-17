using System.Threading.Tasks;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IUserHandler
    {
        public Task<long> AddUserAsync(UserEntity user);
        public Task<bool> ConfirmUserEmailAsync(EmailConfirmationEntity model);
    }
}

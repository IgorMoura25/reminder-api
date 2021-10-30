using System.Threading.Tasks;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IUserHandler
    {
        public Task<ServiceResult<UserEntity>> FindUserByEmailAsync(string email);
        public Task<ServiceResult<long>> AddUserAsync(UserEntity user);
        public Task<ServiceResult<bool>> ConfirmUserEmailAsync(EmailConfirmationEntity model);
    }
}

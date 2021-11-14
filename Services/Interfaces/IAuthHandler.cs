using System.Threading.Tasks;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IAuthHandler
    {
        public Task<ServiceResult<bool>> SignInAsync(SignInEntity model);
        public Task<ServiceResult<bool>> GeneratePasswordRedefinitionTokenAsync(PasswordRedefinitionTokenEntity model);
        public Task<ServiceResult<bool>> ResetPasswordAsync(ResetPasswordEntity model);
    }
}

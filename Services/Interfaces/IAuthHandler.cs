using System.Threading.Tasks;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IAuthHandler
    {
        public Task<ServiceResult<bool>> SignInAsync(SignInEntity model);
    }
}

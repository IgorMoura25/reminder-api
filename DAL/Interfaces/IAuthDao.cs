using System.Threading.Tasks;
using IgorMoura.Reminder.Models.DataObjects.Auth;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface IAuthDao
    {
        public Task<DataResult<bool>> SignInAsync(SignInRequestModel model);
    }
}

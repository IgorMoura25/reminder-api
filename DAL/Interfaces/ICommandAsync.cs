using System.Threading.Tasks;
using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface ICommandAsync
    {
        public Task<string> AddAsync(AddDataRequestModel model);
    }
}

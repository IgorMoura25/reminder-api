using System.Threading.Tasks;

namespace IgorMoura.Reminder.DAL.Interfaces.Base
{
    public interface ICommandAsync<TAddRequestModel>
    {
        public Task<DataResult<long>> AddAsync(TAddRequestModel model);
    }
}

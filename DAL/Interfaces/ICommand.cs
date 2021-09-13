using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface ICommand<T>
    {
        public long Add(AddDataRequestModel model);
    }
}

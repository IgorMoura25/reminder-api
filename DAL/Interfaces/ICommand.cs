using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface ICommand
    {
        public long Add(AddDataRequestModel model);
    }
}

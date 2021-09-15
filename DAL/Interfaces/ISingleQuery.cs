using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.DAL.Interfaces
{
    public interface ISingleQuery<T>
    {
        public T GetById(GetDataRequestModel model);
    }
}

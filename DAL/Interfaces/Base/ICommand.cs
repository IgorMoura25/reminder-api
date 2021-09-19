namespace IgorMoura.Reminder.DAL.Interfaces.Base
{
    public interface ICommand<TAddRequestModel>
    {
        public long Add(TAddRequestModel model);
    }
}

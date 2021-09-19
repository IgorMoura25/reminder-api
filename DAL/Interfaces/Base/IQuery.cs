namespace IgorMoura.Reminder.DAL.Interfaces.Base
{
    public interface IQuery<TGetByIdResponseModel, TGetByIdRequestModel>
    {
        public TGetByIdResponseModel GetById(TGetByIdRequestModel model);
    }
}

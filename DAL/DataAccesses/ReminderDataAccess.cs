using Reminder.Models.DataObjects.Reminder;

namespace DAL.DataAccesses
{
    public class ReminderDataAccess
    {
        public GetReminderByIdResponseModel GetReminderById(GetReminderByIdRequestModel model)
        {
            var teste = new Util.Data.DbConnectors.SqlServerConnector();

            return teste.ExecuteGetProcedure<GetReminderByIdResponseModel>("SP_RMD_GET_ReminderById", model);
        }
    }
}

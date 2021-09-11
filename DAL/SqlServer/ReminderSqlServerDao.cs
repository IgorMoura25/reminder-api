using Reminder.Models.DataObjects.Reminder;

namespace DAL.SqlServer
{
    public class ReminderSqlServerDao : IReminderDao
    {
        public GetReminderByIdResponseModel GetReminderById(GetReminderByIdRequestModel model)
        {
            var connector = new Util.Data.DbConnectors.SqlServerConnector();

            return connector.ExecuteGetProcedure<GetReminderByIdResponseModel>("SP_RMD_GET_ReminderById", model);
        }
    }
}

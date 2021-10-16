using IgorMoura.Util.Data;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.Reminder;
using IgorMoura.Reminder.Extensions.Exceptions.Reminder;

namespace IgorMoura.Reminder.DAL.SqlServer
{
    public class ReminderSqlServerDao : IReminderDao
    {
        private IDbConnector _connector { get; }

        public ReminderSqlServerDao(IDbConnector dbConnector)
        {
            _connector = dbConnector;
        }

        public GetReminderByIdResponseModel GetById(GetReminderByIdRequestModel model)
        {
            var result = _connector.ExecuteGetProcedure<GetReminderByIdResponseModel>("SP_RMD_GET_ReminderById", model);

            return result ?? throw new ReminderNotFoundException();
        }
    }
}

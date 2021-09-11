using DAL;
using DAL.SqlServer;
using Reminder.Models.Entities;

namespace Reminder.Business.Handlers
{
    public class ReminderHandler
    {
        public ReminderEntity GetReminderById(long reminderId)
        {
            IReminderDao dataAccess = new ReminderSqlServerDao();

            var response = dataAccess.GetReminderById(new Models.DataObjects.Reminder.GetReminderByIdRequestModel()
            {
                ReminderId = reminderId
            });

            return new ReminderEntity()
            {
                ReminderId = response.ReminderId,
                CreatedDate = response.CreatedDate,
                UserId = response.UserId,
                ReminderStatusId = response.ReminderStatusId,
                Deadline = response.Deadline
            };
        }
    }
}

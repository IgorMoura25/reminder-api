using DAL.DataAccesses;
using Reminder.Models.Entities;

namespace Reminder.Business.Handlers
{
    public class ReminderHandler
    {
        public ReminderEntity GetReminderById(long reminderId)
        {
            var dataAccess = new ReminderDataAccess();

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

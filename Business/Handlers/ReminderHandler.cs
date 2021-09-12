using IgorMoura.Reminder.DAL;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Business.Handlers
{
    public class ReminderHandler
    {
        private IReminderDao _reminderDao { get; }
        public ReminderHandler(IReminderDao reminderDao)
        {
            _reminderDao = reminderDao;
        }

        public ReminderEntity GetReminderById(long reminderId)
        {
            var response = _reminderDao.GetReminderById(new Models.DataObjects.Reminder.GetReminderByIdRequestModel()
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

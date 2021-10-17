using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Models.DataObjects.Reminder;
using IgorMoura.Reminder.Models.Entities;
using IgorMoura.Reminder.Services.Interfaces;

namespace IgorMoura.Reminder.Services.Handlers
{
    public class ReminderHandler : IReminderHandler
    {
        private IReminderDao _reminderDao { get; }

        public ReminderHandler(IReminderDao reminderDao)
        {
            _reminderDao = reminderDao;
        }

        public ReminderEntity GetReminderById(GetReminderByIdRequestModel model)
        {
            var response = _reminderDao.GetById(model);

            return new ReminderEntity()
            {
                ReminderId = response.ReminderId,
                ReminderStatusId = response.ReminderStatusId,
                Deadline = response.Deadline,
                IsActive = response.IsActive,
                CreatedAt = response.CreatedAt,
                CreatedBy = response.CreatedBy
            };
        }
    }
}

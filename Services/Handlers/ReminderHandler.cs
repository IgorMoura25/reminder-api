using System;
using IgorMoura.Reminder.DAL.Interfaces;
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

        public ReminderEntity GetReminderById(Guid? reminderId)
        {
            var response = _reminderDao.GetById(new Models.DataObjects.Reminder.GetReminderByIdRequestModel()
            {
                ReminderId = reminderId
            });

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

using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.Extensions.ResultCode.Reminder;
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

        public ServiceResult<ReminderEntity> GetReminderById(GetReminderByIdRequestModel model)
        {
            var response = _reminderDao.GetById(model);

            if (response == null)
            {
                return ServiceResultBuilder<ReminderEntity>.Error(new ReminderResultCode().ReminderNotFound);
            }

            var result = new ReminderEntity()
            {
                ReminderId = response.ReminderId,
                ReminderStatusId = response.ReminderStatusId,
                Deadline = response.Deadline,
                IsActive = response.IsActive,
                CreatedAt = response.CreatedAt,
                CreatedBy = response.CreatedBy
            };

            return ServiceResultBuilder<ReminderEntity>.Success(result);
        }
    }
}

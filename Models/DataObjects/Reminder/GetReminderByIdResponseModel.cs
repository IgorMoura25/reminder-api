using System;

namespace IgorMoura.Reminder.Models.DataObjects.Reminder
{
    public class GetReminderByIdResponseModel
    {
        public long ReminderId { get; set; }
        public int ReminderStatusId { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
    }
}

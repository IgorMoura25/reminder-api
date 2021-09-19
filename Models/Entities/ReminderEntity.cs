using System;

namespace IgorMoura.Reminder.Models.Entities
{
    public class ReminderEntity
    {
        public long ReminderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public long ReminderStatusId { get; set; }
        public DateTime Deadline { get; set; }
    }
}

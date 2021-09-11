using System;

namespace Reminder.Models.Entities
{
    public class ReminderEntity
    {
        public long ReminderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public long UserId { get; set; }
        public long ReminderStatusId { get; set; }
        public DateTime Deadline { get; set; }
    }
}

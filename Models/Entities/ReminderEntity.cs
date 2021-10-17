using System;

namespace IgorMoura.Reminder.Models.Entities
{
    public class ReminderEntity
    {
        public Guid? ReminderId { get; set; }
        public int ReminderStatusId { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}

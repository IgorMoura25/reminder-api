using System;

namespace IgorMoura.Reminder.Extensions.Exceptions.Reminder
{
    public class ReminderNotFoundException : Exception
    {
        public ReminderNotFoundException() : base("REMINDER_NOT_FOUND: Reminder not found")
        {
        }
    }
}

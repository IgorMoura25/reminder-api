using System;

namespace IgorMoura.Reminder.Extensions.Exceptions
{
    public class ReminderNotFoundException : Exception
    {
        public ReminderNotFoundException() : base("Reminder not found")
        {
        }

        public readonly string Code = "ReminderNotFound";
    }
}

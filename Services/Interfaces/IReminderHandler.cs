using System;
using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Services.Interfaces
{
    public interface IReminderHandler
    {
        public ReminderEntity GetReminderById(long reminderId);
    }
}

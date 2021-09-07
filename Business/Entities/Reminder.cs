using Reminder.Models;
using System;

namespace Reminder.Business.Entities
{
    public class Reminder
    {
        public ReminderDataObject GetReminderById(long reminderId)
        {
            return new ReminderDataObject()
            {
                ReminderId = 1,
                CreatedDate = DateTime.Now,
                UserId = 8,
                ReminderStatusId = 1,
                Deadline = DateTime.Now.AddDays(7)
            };
        }
    }
}

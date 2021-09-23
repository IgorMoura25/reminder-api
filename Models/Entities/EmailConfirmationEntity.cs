using System;
using System.Collections.Generic;
using System.Text;

namespace IgorMoura.Reminder.Models.Entities
{
    public class EmailConfirmationEntity
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}

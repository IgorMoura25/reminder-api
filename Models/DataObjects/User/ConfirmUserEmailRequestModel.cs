using System;
using System.Collections.Generic;
using System.Text;
using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.Models.DataObjects.User
{
    public class ConfirmUserEmailRequestModel : UpdateDataRequestModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}

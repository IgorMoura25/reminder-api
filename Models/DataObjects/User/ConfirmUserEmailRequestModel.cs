using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.Models.DataObjects.User
{
    public class ConfirmUserEmailRequestModel : UpdateDataRequestModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}

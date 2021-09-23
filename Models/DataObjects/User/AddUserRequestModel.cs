using IgorMoura.Util.Models;

namespace IgorMoura.Reminder.Models.DataObjects.User
{
    public class AddUserRequestModel : AddDataRequestModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

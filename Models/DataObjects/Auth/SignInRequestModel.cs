using IgorMoura.Reminder.Models.Entities;

namespace IgorMoura.Reminder.Models.DataObjects.Auth
{
    public class SignInRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

namespace IgorMoura.Reminder.Models.DataObjects.Auth
{
    public class ResetPasswordRequestModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}

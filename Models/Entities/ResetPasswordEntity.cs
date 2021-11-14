namespace IgorMoura.Reminder.Models.Entities
{
    public class ResetPasswordEntity
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}

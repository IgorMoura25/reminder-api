namespace IgorMoura.Reminder.Models.Entities
{
    public class UserEntity
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}

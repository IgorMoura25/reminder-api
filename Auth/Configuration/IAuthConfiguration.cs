namespace IgorMoura.Reminder.Auth.Configuration
{
    public interface IAuthConfiguration
    {
        public string ConnectionString { get; set; }
        public string EmailHost { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public string SecretKey { get; set; }
        public double DefaultLockoutMinutes { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
    }
}

namespace IgorMoura.Reminder.Api.Configuration
{
    public interface IApiConfiguration
    {
        public string ConnectionString { get; set; }
        public string EmailHost { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
    }
}

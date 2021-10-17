namespace IgorMoura.Reminder.Api.Configuration
{
    public interface IApiConfiguration
    {
        public string ConnectionString { get; set; }
        public string IdentityEmailHost { get; set; }
        public string IdentityEmailUserName { get; set; }
        public string IdentityEmailPassword { get; set; }
    }
}

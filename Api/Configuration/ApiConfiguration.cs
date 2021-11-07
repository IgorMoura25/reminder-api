using Microsoft.Extensions.Configuration;

namespace IgorMoura.Reminder.Api.Configuration
{
    public class ApiConfiguration : IApiConfiguration
    {
        private const string CONFIGURATION_PREFIX = "RMD_API";

        public string ConnectionString { get; set; }
        public string EmailHost { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }

        public ApiConfiguration(IConfiguration configuration)
        {
            ConnectionString = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_CONNECTION_STRING");
            EmailHost = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_EMAIL_HOST");
            EmailUserName = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_EMAIL_USER_NAME");
            EmailPassword = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_EMAIL_PASSWORD");
        }

        public string LoadFromConfiguration(string name)
        {
            return System.Environment.GetEnvironmentVariable(name);
        }
    }
}

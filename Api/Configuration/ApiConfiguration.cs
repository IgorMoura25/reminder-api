using Microsoft.Extensions.Configuration;

namespace IgorMoura.Reminder.Api.Configuration
{
    public class ApiConfiguration : IApiConfiguration
    {
        private const string CONFIGURATION_PREFIX = "RMD_API";

        public string ConnectionString { get; set; }
        public string IdentityEmailHost { get; set; }
        public string IdentityEmailUserName { get; set; }
        public string IdentityEmailPassword { get; set; }

        public ApiConfiguration(IConfiguration configuration)
        {
            ConnectionString = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_CONNECTION_STRING");
            IdentityEmailHost = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_IDENTITY_EMAIL_HOST");
            IdentityEmailUserName = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_IDENTITY_EMAIL_USER_NAME");
            IdentityEmailPassword = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_IDENTITY_EMAIL_PASSWORD");
        }

        public string LoadFromConfiguration(string name)
        {
            return System.Environment.GetEnvironmentVariable(name);
        }
    }
}

using Microsoft.Extensions.Configuration;

namespace IgorMoura.Reminder.Api.Configuration
{
    public class ApiConfiguration : IApiConfiguration
    {
        private const string CONFIGURATION_PREFIX = "RMD_API";

        public string ConnectionString { get; set; }

        public ApiConfiguration(IConfiguration configuration)
        {
            ConnectionString = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_CONNECTION_STRING");
        }

        public string LoadFromConfiguration(string name)
        {
            return System.Environment.GetEnvironmentVariable(name);
        }
    }
}

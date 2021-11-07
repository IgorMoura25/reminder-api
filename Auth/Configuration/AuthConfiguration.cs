using Microsoft.Extensions.Configuration;

namespace IgorMoura.Reminder.Auth.Configuration
{
    public class AuthConfiguration : IAuthConfiguration
    {
        private const string CONFIGURATION_PREFIX = "RMD_AUTH";

        public string ConnectionString { get; set; }
        public string EmailHost { get; set; }
        public string EmailUserName { get; set; }
        public string EmailPassword { get; set; }
        public string SecretKey { get; set; }
        public double DefaultLockoutMinutes { get; set; }
        public int MaxFailedAccessAttempts { get; set; }

        public AuthConfiguration(IConfiguration configuration)
        {
            ConnectionString = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_CONNECTION_STRING");
            EmailHost = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_EMAIL_HOST");
            EmailUserName = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_EMAIL_USER_NAME");
            EmailPassword = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_EMAIL_PASSWORD");
            SecretKey = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_SECRET_KEY");

            var environmentString = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_DEFAULT_LOCKOUT_MINUTES");
            double defaultLockoutMinutes;
            bool success = double.TryParse(environmentString, out defaultLockoutMinutes);

            if (success)
            {
                DefaultLockoutMinutes = defaultLockoutMinutes;
            }

            environmentString = LoadFromConfiguration($"{CONFIGURATION_PREFIX}_MAX_FAILED_ACCESS_ATTEMPTS");
            int maxFailedAccessAttempts;
            success = int.TryParse(environmentString, out maxFailedAccessAttempts);

            if (success)
            {
                MaxFailedAccessAttempts = maxFailedAccessAttempts;
            }
        }

        public string LoadFromConfiguration(string name)
        {
            return System.Environment.GetEnvironmentVariable(name);
        }
    }
}

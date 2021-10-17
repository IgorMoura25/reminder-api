using Microsoft.Extensions.DependencyInjection;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.DAL.SqlServer;
using IgorMoura.Util.Data;
using IgorMoura.Util.Data.DbConnectors;

namespace IgorMoura.Reminder.DAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterConnectors(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDbConnector>(connector => new SqlServerConnector(connectionString));
        }

        public static void RegisterDataAccesses(this IServiceCollection services)
        {
            services.AddSingleton<IReminderDao, ReminderSqlServerDao>();
            services.AddTransient<IUserDao, UserIdentitySqlServerDao>();
        }
    }
}

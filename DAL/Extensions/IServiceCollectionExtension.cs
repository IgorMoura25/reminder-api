using Microsoft.Extensions.DependencyInjection;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.DAL.SqlServer;
using IgorMoura.Util.Data.DbConnectors;
using IgorMoura.Util.Data;

namespace IgorMoura.Reminder.DAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterDataAccesses(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnector, SqlServerConnector>();
            services.AddSingleton<IReminderDao, ReminderSqlServerDao>();
        }
    }
}

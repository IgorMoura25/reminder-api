using Microsoft.Extensions.DependencyInjection;
using IgorMoura.Reminder.DAL.Interfaces;
using IgorMoura.Reminder.DAL.SqlServer;
using IgorMoura.Util.Data.DbConnectors;
using IgorMoura.Util.Data;
using IgorMoura.IdentityDAL.Stores;

namespace IgorMoura.Reminder.DAL.Extensions
{
    //TODO: Aplicar em todas as extensões o TryAddScoped
    //TODO: Quando tudo sobre Identity estiver terminado -> Desacoplar a dependência de projeto com IdentityDAL e acoplar como nuget package
    public static class IServiceCollectionExtension
    {
        public static void RegisterConnectors(this IServiceCollection services)
        { 
            services.AddSingleton<IDbConnector, SqlServerConnector>(); 
        }

        public static void RegisterDataAccesses(this IServiceCollection services)
        {
            services.AddSingleton<IReminderDao, ReminderSqlServerDao>();
            services.AddTransient<IUserDao, UserSqlServerDao>();
            //services.AddSingleton(x => new UserStore(x.GetService<IDbConnector>()));
        }
    }
}

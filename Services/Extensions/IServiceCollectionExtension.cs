using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IgorMoura.Reminder.Services.Handlers;
using IgorMoura.Reminder.Services.Interfaces;

namespace IgorMoura.Reminder.Services.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterHandlers(this IServiceCollection services, string emailHost = null, string emailUserName = null, string emailPassword = null)
        {
            services.AddSingleton<IReminderHandler, ReminderHandler>();
            services.AddTransient<IUserHandler, UserHandler>();

            if (emailHost != null && emailUserName != null && emailPassword != null)
            {
                services.TryAddScoped(x => new EmailHandler(emailHost, emailUserName, emailPassword));
            }
        }
    }
}

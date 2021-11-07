using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IgorMoura.Reminder.Services.Handlers;
using IgorMoura.Reminder.Services.Interfaces;

namespace IgorMoura.Reminder.Services.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterHandlers(this IServiceCollection services, RegisterHandlerOptions options = null)
        {
            services.AddSingleton<IReminderHandler, ReminderHandler>();
            services.AddTransient<IUserHandler, UserHandler>();
            services.AddTransient<IAuthHandler, AuthHandler>();

            if (options != null)
            {
                if (options.Email != null)
                {
                    if (options.Email.Host != null && options.Email.UserName != null && options.Email.Password != null)
                    {
                        services.TryAddScoped(x => new EmailHandler(options.Email.Host, options.Email.UserName, options.Email.Password));
                    }
                }
            }
        }
    }
}

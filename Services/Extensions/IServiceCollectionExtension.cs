using IgorMoura.Reminder.Services.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace IgorMoura.Reminder.Services.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddSingleton<ReminderHandler>();
        }
    }
}

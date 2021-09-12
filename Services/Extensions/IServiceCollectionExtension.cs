using Microsoft.Extensions.DependencyInjection;
using IgorMoura.Reminder.Services.Handlers;
using Reminder.Services.Interfaces;

namespace IgorMoura.Reminder.Services.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IReminderHandler, ReminderHandler>();
        }
    }
}

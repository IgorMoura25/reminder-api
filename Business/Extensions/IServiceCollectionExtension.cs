using IgorMoura.Reminder.Business.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace IgorMoura.Reminder.Business.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddSingleton<ReminderHandler>();
        }
    }
}

﻿using IgorMoura.Reminder.DAL;
using IgorMoura.Reminder.DAL.SqlServer;
using Microsoft.Extensions.DependencyInjection;

namespace IgorMoura.Reminder.Business.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterDataAccesses(this IServiceCollection services)
        {
            services.AddSingleton<IReminderDao, ReminderSqlServerDao>();
        }
    }
}

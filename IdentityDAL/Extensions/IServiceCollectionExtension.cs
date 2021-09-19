using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IgorMoura.IdentityDAL.Stores;

namespace IgorMoura.IdentityDAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterIdentity(this IServiceCollection services)
        {
            //services.AddSingleton(x => IUserStore<>, new UserStore(x.GetService<IDbConnector>()));
            services.AddSingleton<IUserStore<IdentityUser>, UserStore>();
            services.AddTransient<UserManager<IdentityUser>, UserManager<IdentityUser>>();
        }
    }
}

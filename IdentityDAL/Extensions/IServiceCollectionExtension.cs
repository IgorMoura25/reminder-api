using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IgorMoura.IdentityDAL.Stores;

namespace IgorMoura.IdentityDAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterIdentity(this IServiceCollection services)
        {
            services.AddSingleton<IUserStore<IdentityUser>, UserStore>();
            services.AddSingleton<IRoleStore<IdentityRole>, RoleStore>();
            services.AddTransient<UserManager<IdentityUser>, UserManager<IdentityUser>>();
        }
    }
}

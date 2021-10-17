using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using IgorMoura.IdentityDAL.Stores;
using IgorMoura.IdentityDAL.Services;

namespace IgorMoura.IdentityDAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterIdentity(this IServiceCollection services, string emailHost = null, string emailUserName = null, string emailPassword = null)
        {
            services.AddSingleton<IUserStore<IdentityUser>, UserStore>();
            services.AddTransient<UserManager<IdentityUser>, UserManager<IdentityUser>>();

            if (emailHost != null && emailUserName != null && emailPassword != null)
            {
                services.TryAddScoped(x => new IdentityEmailService(emailHost, emailUserName, emailPassword));
            }
        }
    }
}

using IgorMoura.IdentityDAL.Stores;
using IgorMoura.Util.Data;
using Microsoft.Extensions.DependencyInjection;

namespace IgorMoura.IdentityDAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterCustomIdentityStore(this IServiceCollection services)
        {
            services.AddSingleton(x => new UserStore(x.GetService<IDbConnector>()));
        }
    }
}

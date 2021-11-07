using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IgorMoura.IdentityDAL.Stores;

namespace IgorMoura.IdentityDAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterIdentity(this IServiceCollection services, RegisterIdentityOptions options = null)
        {
            services.AddSingleton<IUserStore<IdentityUser>, UserStore>();
            services.AddSingleton<IRoleStore<IdentityRole>, RoleStore>();
            services.AddTransient<UserManager<IdentityUser>, UserManager<IdentityUser>>();

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;

                if (options != null)
                {
                    if (options.Lockout != null)
                    {
                        options.Lockout.AllowedForNewUsers = options.Lockout.AllowedForNewUsers;
                        options.Lockout.DefaultLockoutTimeSpan = options.Lockout.DefaultLockoutTimeSpan;
                        options.Lockout.MaxFailedAccessAttempts = options.Lockout.MaxFailedAccessAttempts;
                    }
                }
            })
            .AddDefaultTokenProviders();

            services.Configure<PasswordHasherOptions>(option =>
            {
                option.IterationCount = 12000;
            });
        }
    }
}

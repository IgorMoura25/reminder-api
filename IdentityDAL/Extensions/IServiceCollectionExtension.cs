using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using IgorMoura.IdentityDAL.Stores;

namespace IgorMoura.IdentityDAL.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterIdentity(this IServiceCollection services, RegisterIdentityOptions customOptions = null)
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

                if (customOptions != null)
                {
                    if (customOptions.Lockout != null)
                    {
                        options.Lockout.AllowedForNewUsers = customOptions.Lockout.AllowedForNewUsers;
                        options.Lockout.DefaultLockoutTimeSpan = customOptions.Lockout.DefaultLockoutTimeSpan;
                        options.Lockout.MaxFailedAccessAttempts = customOptions.Lockout.MaxFailedAccessAttempts;
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

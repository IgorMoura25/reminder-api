using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IgorMoura.Reminder.Auth.Configuration;
using IgorMoura.Reminder.Services.Extensions;
using IgorMoura.Reminder.DAL.Extensions;
using IgorMoura.IdentityDAL.Extensions;

namespace Auth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DotNetEnv.Env.Load();
            IAuthConfiguration authConfiguration = new AuthConfiguration(Configuration);
            services.AddSingleton(authConfiguration);

            // DI Registration
            services.RegisterConnectors(authConfiguration.ConnectionString);
            services.RegisterIdentity(customOptions: new RegisterIdentityOptions()
            {
                Lockout = new LockoutOption()
                {
                    AllowedForNewUsers = true,
                    DefaultLockoutTimeSpan = authConfiguration.DefaultLockoutMinutes > 0 ? TimeSpan.FromMinutes(authConfiguration.DefaultLockoutMinutes) : TimeSpan.FromMinutes(3),
                    MaxFailedAccessAttempts = authConfiguration.MaxFailedAccessAttempts > 0 ? authConfiguration.MaxFailedAccessAttempts : 3
                }
            });
            services.RegisterDataAccesses();
            services.RegisterHandlers(options: new RegisterHandlerOptions()
            {
                Email = new EmailOption()
                {
                    Host = authConfiguration.EmailHost,
                    UserName = authConfiguration.EmailUserName,
                    Password = authConfiguration.EmailPassword
                }
            });

            services.AddControllers();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reminder Auth", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Reminder Auth v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using IgorMoura.Reminder.DAL.Extensions;
using IgorMoura.Reminder.Services.Extensions;
using IgorMoura.IdentityDAL.Extensions;
using IgorMoura.Reminder.Api.Configuration;

namespace IgorMoura.Reminder.Api
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
            var teste = DotNetEnv.Env.Load();

            IApiConfiguration apiConfiguration = new ApiConfiguration(Configuration);
            services.AddSingleton(apiConfiguration);

            // DI Registration
            //services.RegisterConnectors("Server=localhost; Database=Reminder_Dev; User Id=sa; Password=Cerc@tr0va-sqlserver;");
            services.RegisterConnectors(apiConfiguration.ConnectionString);
            services.RegisterIdentity(apiConfiguration.IdentityEmailHost, apiConfiguration.IdentityEmailUserName, apiConfiguration.IdentityEmailPassword);
            services.RegisterDataAccesses();
            services.RegisterHandlers();

            services.AddIdentityCore<IdentityUser>(options =>
            {
                options.User.RequireUniqueEmail = true;

                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            })
            .AddDefaultTokenProviders();

            services.Configure<PasswordHasherOptions>(option =>
            {
                option.IterationCount = 12000;
            });

            services.AddControllers();

            // JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("token-maior-que-256-bits-guid")),
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = "Reminder.Api",
                    ValidAudience = "Postman"
                };
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reminder API", Version = Version.ProductVersion });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"Reminder API {Version.ProductVersion}");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

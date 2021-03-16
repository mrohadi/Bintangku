using Bintangku.Data;
using Bintangku.Services.Interfaces;
using Bintangku.Services.Repository;
using Bintangku.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bintangku.Services.Helpers;
using Newtonsoft.Json;
using System;

namespace Bintangku.Services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<INakesUserRepository, NakesUserRepository>();
            // Json serializer config to ignore object cycle problem
            services.AddMvc().AddNewtonsoftJson(
                options => {options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddDbContext<ApplicationDataContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
 
                string connStr;
 
                if (env == "Development")
                {
                    connStr = config.GetConnectionString("DefaultConnection");
                }
                else
                {
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
 
                    connUrl = connUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];
 
                    connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}sslmode=Prefer;Trust Server Certificate=true;";
                }
                options.UseNpgsql(connStr);
            });

            return services;
        }
    }
}
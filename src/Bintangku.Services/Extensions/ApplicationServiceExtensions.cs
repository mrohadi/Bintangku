using Bintangku.Data;
using Bintangku.Services.Interfaces;
using Bintangku.Services.Repository;
using Bintangku.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bintangku.Services.Helpers;
using Newtonsoft.Json;

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
                options.UseSqlite(
                    config.GetConnectionString("DefaultConnection")
                    );
            });

            return services;
        }
    }
}
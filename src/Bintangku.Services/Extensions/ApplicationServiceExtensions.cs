using Bintangku.Data;
using Bintangku.Services.Interfaces;
using Bintangku.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bintangku.Services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
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
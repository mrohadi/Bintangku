using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Bintangku.Services.Extensions;
using Bintangku.Services.Middleware;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Bintangku.WebApi.Helpers;
using Microsoft.Extensions.Primitives;

namespace Bintangku.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Extension method for application services
            services.AddApplicationServices(_config);
            // Extension method for identity services
            services.AddIdentityServices(_config);
            services.AddControllers();
            services.AddCors();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bintangku.WebApi", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseMiddleware<ExceptionsMiddleware>();

            app.UseHttpsRedirection();

            app.UseCors(policy => 
                policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("https://localhost:4200"));

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProviderCustom(
                            Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images")),
                RequestPath = Path.Combine(env.ContentRootPath, "/Resources/Images")
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }

    public class PhysicalFileProviderCustom : IFileProvider
    {
        private string _root;
        private PhysicalFileProvider _physicalFileProvider;
        public PhysicalFileProviderCustom(string root)
        {
            _root = root;
        }
        
        private PhysicalFileProvider GetPhysicalFileProvider()
        {
            if (!File.Exists(_root))
                Directory.CreateDirectory(_root);
            
            if (_physicalFileProvider == null)
                _physicalFileProvider = new PhysicalFileProvider(_root);
            
            return _physicalFileProvider;
        }
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return GetPhysicalFileProvider().GetDirectoryContents(subpath);
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            return GetPhysicalFileProvider().GetFileInfo(subpath);
        }

        public IChangeToken Watch(string filter)
        {
            return GetPhysicalFileProvider().Watch(filter);
        }
    }
}

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Saber.Vendor.CORS
{
    public class Startup : IVendorStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfigurationRoot config)
        {
            //use CORS for cross-domain requests
            ConfigureCORS(app);
        }

        private void ConfigureCORS(IApplicationBuilder app)
        {
            //use CORS for cross-domain requests
            var config = new ConfigurationBuilder()
                    .AddJsonFile(Server.MapPath("/Vendor/CORS/config.json")).Build();

            var origins = new string[] { };

            switch (Server.environment)
            {
                case Server.Environment.development:
                    origins = config.GetSection("origins:development").Get<string[]>();
                    break;
                case Server.Environment.production:
                    origins = config.GetSection("origins:production").Get<string[]>();
                    break;
                case Server.Environment.staging:
                    origins = config.GetSection("origins:staging").Get<string[]>();
                    break;
            }

            Console.WriteLine("found CORS origins: " + string.Join("; ", origins));

            app.UseCors(builder =>
            {
                builder.WithOrigins(origins)
                .WithHeaders("GET", "POST", "OPTIONS")
                .WithHeaders("*")
                .AllowCredentials();
            });
        }
    }
}

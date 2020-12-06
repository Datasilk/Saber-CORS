using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Saber.Vendor;

namespace Saber.Vendors.CORS
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
            var file = App.MapPath("/Vendors/CORS/config.json");
            if (!System.IO.File.Exists(file))
            {
                Console.WriteLine("You must copy, rename, then modify \"/Vendors/CORS/config.template.json\" to \"/Vendors/CORS/config.json\" and restart Saber to use CORS.");
                return;
            }
            var config = new ConfigurationBuilder()
                    .AddJsonFile(file).Build();

            var origins = new string[] { };
            var section = "";
            try
            {
                switch (App.Environment)
                {
                    case Environment.development:
                        section = "origins:development";
                        break;
                    case Environment.production:
                        section = "origins:production";
                        break;
                    case Environment.staging:
                        section = "origins:staging";
                        break;
                }

                origins = config.GetSection(section).Get<string[]>().Where(a => a != "").ToArray();
            }
            catch (Exception)
            {
                Console.WriteLine("configuration section " + section + " does not contain any values in /Vendors/CORS/config.json");
            }

            if(origins.Length > 0)
            {
                Console.WriteLine("found CORS origins: " + string.Join("; ", origins));

                app.UseCors(builder =>
                {
                    builder.WithOrigins(origins)
                    .WithHeaders("GET", "POST", "OPTIONS")
                    .WithHeaders("*")
                    .AllowCredentials();
                });
            }
            else
            {
                Console.WriteLine("No CORS origins defined for " + section);
            }
        }
    }
}

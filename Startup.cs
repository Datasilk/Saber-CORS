using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public partial class Startup : Datasilk.Startup
{

    partial void ConfigureVendorServices(IServiceCollection services)
    {
        services.AddCors();
    }

    partial void ConfigureVendors(IApplicationBuilder app)
    {
        ConfigureCORS(app);
    }

    private void ConfigureCORS(IApplicationBuilder app)
    {
        //use CORS for cross-domain requests
        var config = new ConfigurationBuilder()
                .AddJsonFile(Server.MapPath("/Vendor/CORS/config.json"))
                .AddEnvironmentVariables().Build();

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

        app.UseCors(builder =>
        {
            builder.WithOrigins(
                "chrome-extension://" +
                (
                    Server.environment == Server.Environment.development ?
                    "kdcpigikfhpokfbbklgdeeheajkndiam" :  //development
                    "" //production
                )
            )
            .WithHeaders("GET", "POST", "OPTIONS")
            .WithHeaders("*")
            .AllowCredentials();
        });
    }
}

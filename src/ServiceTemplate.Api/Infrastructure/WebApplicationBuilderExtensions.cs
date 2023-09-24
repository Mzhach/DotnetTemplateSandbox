using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ServiceTemplate.Api.Infrastructure;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder SetupConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.Sources.Clear();
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddJsonFile("serilogsettings.json", false)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();

        return builder;
    }

    public static WebApplicationBuilder SetupLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((context, services, configuration) =>
        {
            configuration
                .ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services);
        });

        return builder;
    }
}
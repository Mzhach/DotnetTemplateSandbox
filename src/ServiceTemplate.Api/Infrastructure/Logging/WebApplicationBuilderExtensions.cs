using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ServiceTemplate.Api.Infrastructure.Logging;

public static class WebApplicationBuilderExtensions
{
	public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
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
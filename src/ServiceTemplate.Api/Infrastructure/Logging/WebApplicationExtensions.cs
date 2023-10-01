using Microsoft.AspNetCore.Builder;
using Serilog;

namespace ServiceTemplate.Api.Infrastructure.Logging;

public static class WebApplicationExtensions
{
	public static WebApplication UseLogging(this WebApplication app)
	{
		app.UseSerilogRequestLogging();
		return app;
	}
}
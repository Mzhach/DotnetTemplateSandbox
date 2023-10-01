using Microsoft.AspNetCore.Builder;

namespace ServiceTemplate.Api.Infrastructure.Swagger;

public static class WebApplicationExtensions
{
	public static WebApplication UseSwagger(this WebApplication app)
	{
		SwaggerBuilderExtensions.UseSwagger(app);
		app.UseSwaggerUI();

		return app;
	}
}
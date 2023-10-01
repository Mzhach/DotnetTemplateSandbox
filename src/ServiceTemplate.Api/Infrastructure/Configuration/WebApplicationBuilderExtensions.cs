using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace ServiceTemplate.Api.Infrastructure.Configuration;

public static class WebApplicationBuilderExtensions
{
	public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
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
}
using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using ServiceTemplate.Api.Helpers;
using ServiceTemplate.Api.Infrastructure.Configuration;
using ServiceTemplate.Api.Infrastructure.Logging;
using ServiceTemplate.Api.Infrastructure.Swagger;
using ServiceTemplate.Application;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console(new JsonFormatter())
	.CreateBootstrapLogger();

try
{
	Log.Information("Starting web application");

	var builder = WebApplication.CreateBuilder(args);
	builder.AddConfiguration();
	builder.ConfigureLogging();

	var configurationHelper = new ConfigurationHelper(builder.Configuration);

	builder.Services.AddControllers();
	builder.Services.AddApplicationServices();

	if (configurationHelper.IsSwaggerEnabled)
		builder.Services.AddSwagger();

	var app = builder.Build();

	if (configurationHelper.IsSwaggerEnabled)
		app.UseSwagger();

	app.UseLogging();
	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}

[UsedImplicitly]
public partial class Program
{
}
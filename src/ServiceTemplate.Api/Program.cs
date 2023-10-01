using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using ServiceTemplate.Api.Infrastructure.Configuration;
using ServiceTemplate.Api.Infrastructure.Logging;
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

	builder.Services.AddControllers();
	builder.Services.AddSwaggerGen();
	builder.Services.AddApplicationServices();

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

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
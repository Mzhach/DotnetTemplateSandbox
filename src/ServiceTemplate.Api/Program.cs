using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;
using ServiceTemplate.Api.Infrastructure;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console(new JsonFormatter())
	.CreateBootstrapLogger();

try
{
	Log.Information("Starting web application");

	var builder = WebApplication.CreateBuilder(args)
		.SetupConfiguration()
		.SetupLogging();

	builder.Services.AddControllers();
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	var app = builder.Build();

	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseSerilogRequestLogging();
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
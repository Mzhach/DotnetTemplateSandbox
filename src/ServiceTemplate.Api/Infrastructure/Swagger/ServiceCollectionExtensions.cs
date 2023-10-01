using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ServiceTemplate.Api.Constants;
using Swashbuckle.AspNetCore.Filters;

namespace ServiceTemplate.Api.Infrastructure.Swagger;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddSwagger(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddSwaggerGen(options =>
		{
			options.SwaggerDoc(ApiConstants.V1, new OpenApiInfo
			{
				Version = ApiConstants.V1,
				Title = "ServiceTemplate"
			});

			options.EnableAnnotations();
			options.ExampleFilters();

			var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
			options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{assemblyName}.xml"));
		});

		serviceCollection.AddSwaggerExamplesFromAssemblyOf<Program>();

		return serviceCollection;
	}
}
using Microsoft.Extensions.DependencyInjection;

namespace ServiceTemplate.Application;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection) =>
		serviceCollection;
}
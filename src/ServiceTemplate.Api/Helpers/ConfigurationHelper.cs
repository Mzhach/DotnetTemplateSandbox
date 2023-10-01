using Microsoft.Extensions.Configuration;
using ServiceTemplate.Api.Constants;

namespace ServiceTemplate.Api.Helpers;

public class ConfigurationHelper
{
	private readonly IConfiguration _configuration;

	public ConfigurationHelper(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public bool IsSwaggerEnabled => _configuration.GetValue<bool>(ConfigurationConstants.SwaggerFeatureFlag);
}
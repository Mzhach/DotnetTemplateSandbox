using System;
using System.Collections.Generic;
using ServiceTemplate.Api.Models.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace ServiceTemplate.Api.Models.v1.Examples;

public class WeatherModelExamples : IMultipleExamplesProvider<WeatherModel>
{
	public IEnumerable<SwaggerExample<WeatherModel>> GetExamples()
	{
		yield return SwaggerExample.Create("Sunny weather", new WeatherModel
		{
			Date = DateOnly.FromDateTime(DateTime.UtcNow),
			Temperature = 20,
			Type = WeatherType.Sunny
		});

		yield return SwaggerExample.Create("Cloudy weather", new WeatherModel
		{
			Date = DateOnly.FromDateTime(DateTime.UtcNow),
			Temperature = 15,
			Type = WeatherType.Cloudy
		});
	}
}
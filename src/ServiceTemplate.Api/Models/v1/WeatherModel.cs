using System;
using ServiceTemplate.Api.Models.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace ServiceTemplate.Api.Models.v1;

[SwaggerSchema(Required = new[] { "date" })]
public class WeatherModel
{
	/// <summary>
	/// Date
	/// </summary>
	public DateOnly Date { get; set; }

	/// <summary>
	/// Temperature in Celsius
	/// </summary>
	public int Temperature { get; set; }

	/// <summary>
	/// Weather type
	/// </summary>
	public WeatherType Type { get; set; }
}
using System;
using System.Collections.Concurrent;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceTemplate.Api.Constants;
using ServiceTemplate.Api.Models.v1;
using ServiceTemplate.Api.Models.v1.Examples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace ServiceTemplate.Api.Controllers.v1;

[ApiController]
[Route($"api/{ApiConstants.V1}/weather")]
public class WeatherController : ControllerBase
{
	private static readonly ConcurrentDictionary<DateOnly, WeatherModel> Calendar = new();

	/// <summary>
	/// Add or update weather for the day
	/// </summary>
	[HttpPut]
	[SwaggerRequestExample(typeof(WeatherModel), typeof(WeatherModelExamples))]
	[SwaggerResponse((int)HttpStatusCode.OK, "Added or updated weather model")]
	[SwaggerResponse((int)HttpStatusCode.BadRequest, "Date is not specified")]
	public IActionResult Put(WeatherModel model)
	{
		if (model is null) throw new ArgumentNullException(nameof(model));
		if (model.Date == DateOnly.MinValue) throw new ArgumentException("Date is not specified");

		Calendar.AddOrUpdate(model.Date, model, (_, _) => model);
		return Ok(model);
	}

	/// <summary>
	/// Gets weather for the day
	/// </summary>
	[HttpGet]
	[SwaggerResponse((int)HttpStatusCode.OK, "Found weather model")]
	[SwaggerResponse((int)HttpStatusCode.BadRequest, "Date is not specified")]
	[SwaggerResponse((int)HttpStatusCode.NotFound, "Weather by date is not found")]
	public IActionResult Get([FromQuery] [SwaggerParameter("Date", Required = true)] DateOnly date)
	{
		if (date == DateOnly.MinValue) throw new ArgumentException("Date is not specified");
		if (!Calendar.TryGetValue(date, out var model)) return NotFound();
		return Ok(model);
	}

	/// <summary>
	/// Deletes weather for the day
	/// </summary>
	[HttpDelete]
	[SwaggerResponse((int)HttpStatusCode.OK, "Deleted weather model")]
	[SwaggerResponse((int)HttpStatusCode.BadRequest, "Date is not specified")]
	[SwaggerResponse((int)HttpStatusCode.NotFound, "Weather by date is not found")]
	public IActionResult Delete([FromQuery] [SwaggerParameter("Date", Required = true)] DateOnly date)
	{
		if (date == DateOnly.MinValue) throw new ArgumentException("Date is not specified");
		if (!Calendar.TryRemove(date, out var model)) return NotFound();
		return Ok(model);
	}
}
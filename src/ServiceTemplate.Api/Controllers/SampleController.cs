using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceTemplate.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
	private readonly ILogger<SampleController> _logger;

	public SampleController(ILogger<SampleController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public IActionResult Ping() => Ok("Pong");
}
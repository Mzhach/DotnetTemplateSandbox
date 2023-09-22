using Microsoft.AspNetCore.Mvc;

namespace ServiceTemplate.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}
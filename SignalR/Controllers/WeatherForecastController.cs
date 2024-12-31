using Microsoft.AspNetCore.Mvc;

namespace SignalR.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Environment.GetEnvironmentVariable("SERVER"));
    }
}

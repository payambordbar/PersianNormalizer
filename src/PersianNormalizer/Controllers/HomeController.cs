using Microsoft.AspNetCore.Mvc;

namespace PersianNormalizer.Controllers;

[ApiController]
[Route("[controller]/")]
public class HomeController : ControllerBase
{
    [HttpGet("{str}")]
    public IActionResult FromRoute([FromRoute] string str)
    {
        return Ok(str);
    }

    [HttpGet]
    public IActionResult FromQuery([FromQuery] string str)
    {
        return Ok(str);
    }

    [HttpPost("body")]
    public IActionResult FromBody([FromBody] Input input)
    {
        return Ok(input.Str);
    }

    [HttpPost("form")]
    public IActionResult FromForm([FromForm] Input input)
    {
        return Ok(input.Str);
    }
}

public record Input(string Str);
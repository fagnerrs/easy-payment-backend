using Microsoft.AspNetCore.Mvc;

namespace EP.Notifications.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSuccess()
    {
        return Ok("Success");
    }
    
    [HttpPost]
    public IActionResult Send()
    {
        return Ok("Email sent");
    }
}
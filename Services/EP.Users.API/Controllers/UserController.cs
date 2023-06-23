using EP.Users.Domain.Models;
using EP.Users.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EP.Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    
    [HttpPut]
    public  Task<IActionResult> UpdateUser([FromBody] User user)
    {
        return new Task<IActionResult>(Ok);
    }
    
    [HttpPost]
    public async Task<long> AddUser([FromBody] User user)
    {
        return await userService.Add(user);
    }
 
    [HttpDelete("{userId}")]
    public async Task DeleteUser(long userId)
    {
         await userService.Remove(userId);
    }
    
    [HttpGet("{userId}")]
    public async Task<User> GetUser(long userId)
    {
        return await userService.Get(userId);
    }
}
using EP.Shared.Domain.Models;
using EP.User.Domain.Models;
using EP.User.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EP.Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizerController : ControllerBase
{
    private readonly IOrganizerService organizerService;

    public OrganizerController(IOrganizerService organizerService)
    {
        this.organizerService = organizerService;
    }
    
    [HttpPut]
    public  Task<IActionResult> UpdateOrganizer([FromBody] string address)
    {
        return new Task<IActionResult>(Ok);
    }
    [HttpPost]
    public async Task<long> AddOrganizer([FromBody] Organizer organizer)
    {
        return await organizerService.Add(organizer);
    }
    
    [HttpPost("salesperson")]
    public async Task<long> AddSalesPerson([FromBody] SalesPerson salesPerson)
    {
        return await organizerService.AddSalesperson(salesPerson);
    }
    
    [HttpGet("{organizerId}/salespeople")]
    public async Task<List<SalesPerson>> GetSalesPeople(long organizerId)
    {
        return await organizerService.GetSalesPeople(organizerId);
    }
}
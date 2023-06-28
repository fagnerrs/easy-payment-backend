using EP.Products.Domain.Models;
using EP.Products.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EP.Products.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RifaController : ControllerBase
{
    private readonly IRifaService rifaService;

    public RifaController(IRifaService rifaService)
    {
        this.rifaService = rifaService;
    }
    
    [HttpPut]
    public async Task UpdateRifa([FromBody] Rifa rifa)
    {
        await rifaService.Update(rifa);
    }

    [HttpPost]
    public async Task AddRifa([FromBody] Rifa rifa)
    {
        await rifaService.Add(rifa);
    }
    
    [HttpPost("order")]
    public async Task RifaOrder([FromBody] RifaOrder rifaOrder)
    {
        await rifaService.Order(rifaOrder);
    }
}
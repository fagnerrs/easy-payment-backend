using EP.Shared.Domain.Models;
using EP.User.Domain.Models;
using EP.User.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EP.Users.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesPersonController : ControllerBase
{
    private readonly ISalesPersonService salesPersonService;

    public SalesPersonController(ISalesPersonService salesPersonService)
    {
        this.salesPersonService = salesPersonService;
    }
    
    [HttpPost]
    public async Task<long> AddSalesPerson([FromBody] SalesPerson salesPerson)
    {
        return await salesPersonService.Add(salesPerson);
    }
}
using EP.Products.Domain.Models;

namespace EP.Products.Domain.Services.Interfaces;

public interface IRifaService
{
    Task<long> Add(Rifa rifa);
    
    Task<long> Order(RifaOrder rifa);
    
    Task Update(Rifa rifa);
}
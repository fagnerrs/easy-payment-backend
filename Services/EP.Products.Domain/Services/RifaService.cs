using EP.Products.Domain.Models;
using EP.Products.Domain.Services.Interfaces;
using EP.Shared.Domain.EntityFramework;

namespace EP.Products.Domain.Services;

public class RifaService : IRifaService
{
    private readonly IProductUnitOfWork productUnitOfWork;
    private readonly IGenericRepository<Rifa> rifaRepository;
    private readonly IGenericRepository<RifaOrder> rifaOrderRepository;

    public RifaService(IProductUnitOfWork productUnitOfWork )
    {
        this.rifaRepository = productUnitOfWork.GetGenericRepository<Rifa>();
        this.rifaOrderRepository = productUnitOfWork.GetGenericRepository<RifaOrder>();
        this.productUnitOfWork = productUnitOfWork;
    }
    
    public Task<long> Add(Rifa rifa)
    {
        rifaRepository.Add(rifa);
        return productUnitOfWork.Save();
    }

    public Task<long> Order(RifaOrder rifa)
    {
        rifaOrderRepository.Add(rifa);
        return productUnitOfWork.Save();
    }

    public Task Update(Rifa rifa)
    {
        rifaRepository.Update(rifa);
        return productUnitOfWork.Save();
    }
}
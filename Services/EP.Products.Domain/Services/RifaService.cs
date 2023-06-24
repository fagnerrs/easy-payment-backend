using EP.Products.Domain.Exceptions;
using EP.Products.Domain.Models;
using EP.Products.Domain.Services.Interfaces;
using EP.Shared.Domain.EntityFramework;

namespace EP.Products.Domain.Services;

public class RifaService : IRifaService
{
    private readonly IProductUnitOfWork productUnitOfWork;
    private readonly IGenericRepository<Customer> customerRepository;
    private readonly IGenericRepository<Rifa> rifaRepository;
    private readonly IGenericRepository<RifaOrder> rifaOrderRepository;
    private readonly IGenericRepository<RifaSoldNumber> rifaSoldNumbers;

    public RifaService(IProductUnitOfWork productUnitOfWork)
    {
        this.rifaRepository = productUnitOfWork.GetGenericRepository<Rifa>();
        this.rifaOrderRepository = productUnitOfWork.GetGenericRepository<RifaOrder>();
        this.productUnitOfWork = productUnitOfWork;
        this.customerRepository = productUnitOfWork.GetGenericRepository<Customer>();
        this.rifaSoldNumbers = productUnitOfWork.GetGenericRepository<RifaSoldNumber>();
    }

    public async Task<long> Add(Rifa rifa)
    {
        rifaRepository.Add(rifa);
        await productUnitOfWork.Save();
        return rifa.Id;
    }

    public async Task<long> Order(RifaOrder rifaOrder)
    {
        // Check whether Rifa is still active
        var rifa = await rifaRepository.GetByIdAsync(rifaOrder.RifaId);
        if (!rifa.IsActive)
        {
            throw new RifaOrderException("Error adding order. Rifa is inactive");
        }

        // Check whether all numbers are still available or not
        var soldNumbers = rifaSoldNumbers.GetEntityQueryable(w => w.RifaId == rifaOrder.RifaId).ToList();
        var matchingNumbers = soldNumbers.Select(s => s.Number)
            .Where(w => rifaOrder.SoldNumbers.Select(s => s.Number).Contains(w));
        if (matchingNumbers.Any())
        {
            throw new RifaOrderException($"Error adding order. Numbers {string.Join(',', matchingNumbers)} are sold.");
        }

        // Save Customer
        var customer = customerRepository.GetEntityQueryable(w => w.Email == rifaOrder.Customer.Email).FirstOrDefault();
        if (customer == null)
        {
            customerRepository.Add(rifaOrder.Customer);
            await productUnitOfWork.Save();
        }
        
        rifaOrder.CustomerId = rifaOrder.Customer.Id;

        rifaOrderRepository.Add(rifaOrder);
        await productUnitOfWork.Save();

        return rifaOrder.Id;
    }

    public Task Update(Rifa rifa)
    {
        rifaRepository.Update(rifa);
        return productUnitOfWork.Save();
    }

    public List<Rifa> GetAvailableRifas(long salesPersonId)
    {
        return rifaRepository.GetEntityQueryable(w => w.IsActive &&
            w.IsPublic || w.AllowedSalesPeople.Select(s=>s.SalesPersonId).Contains(salesPersonId)).ToList();
    }
}
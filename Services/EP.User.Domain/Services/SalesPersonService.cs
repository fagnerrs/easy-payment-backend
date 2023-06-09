using EP.Shared.Domain.EntityFramework;
using EP.Shared.Domain.Models;
using EP.User.Domain.Services.Interfaces;

namespace EP.User.Domain.Services;

public class SalesPersonService : ISalesPersonService
{
    private readonly IUserUnitOfWork userUnitOfWork;
    private readonly IGenericRepository<SalesPerson> salesPersonRepository;
    
    public SalesPersonService(IUserUnitOfWork userUnitOfWork)
    {
        this.salesPersonRepository = userUnitOfWork.GetGenericRepository<SalesPerson>();
        this.userUnitOfWork = userUnitOfWork;
    }
    
    public async Task<long> Add(SalesPerson salesPerson)
    {
        this.salesPersonRepository.Add(salesPerson);
        return await userUnitOfWork.Save();
    }

    public Task<List<SalesPerson>> GetByOrganizer(long organizerId)
    {
        return Task.FromResult(this.salesPersonRepository.GetEntityQueryable(w => w.OrganizerId == organizerId).ToList());
    }
}
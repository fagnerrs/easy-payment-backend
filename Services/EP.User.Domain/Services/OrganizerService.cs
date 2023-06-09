using EP.Shared.Domain.EntityFramework;
using EP.Shared.Domain.Models;
using EP.User.Domain.Models;
using EP.User.Domain.Services.Interfaces;

namespace EP.User.Domain.Services;

public class OrganizerService : IOrganizerService
{
    private readonly IGenericRepository<Organizer> organizerRepository;
    private readonly IUserUnitOfWork userUnitOfWork;
    private readonly ISalesPersonService salesPersonService;

    public OrganizerService(IUserUnitOfWork userUnitOfWork,
        ISalesPersonService salesPersonService)
    {
        this.organizerRepository = userUnitOfWork.GetGenericRepository<Organizer>();
        this.userUnitOfWork = userUnitOfWork;
        this.salesPersonService = salesPersonService;
    }
    public async Task<long> Add(Organizer organizer)
    {
        organizerRepository.Add(organizer);
        return await userUnitOfWork.Save();
    }

    public async Task<long> AddSalesperson(SalesPerson salesPerson)
    {
        return await salesPersonService.Add(salesPerson);
    }

    public async Task<List<SalesPerson>> GetSalesPeople(long organizerId)
    {
        return await salesPersonService.GetByOrganizer(organizerId);
    }
}


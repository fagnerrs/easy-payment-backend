using EP.Shared.Domain.Models;

namespace EP.User.Domain.Services.Interfaces;

public interface ISalesPersonService
{
    Task<long> Add(SalesPerson salesPerson);
    Task<List<SalesPerson>> GetByOrganizer(long organizerId);
}
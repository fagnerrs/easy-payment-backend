using EP.Shared.Domain.Models;
using EP.User.Domain.Models;

namespace EP.User.Domain.Services.Interfaces;

public interface IOrganizerService
{
    Task<long> Add(Organizer organizer);
    Task<long> AddSalesperson(SalesPerson salesPerson);
    Task<List<SalesPerson>> GetSalesPeople(long organizerId);
}
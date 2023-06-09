using EP.User.Domain.Models;

namespace EP.Shared.Domain.Models;

public class SalesPerson : Person
{
    public long? OrganizerId { get; set; }
}
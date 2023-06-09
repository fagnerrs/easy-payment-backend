namespace EP.Products.Domain.Models;

public class Rifa
{
    public long Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public long NumberStart { get; set; }
    public long NumberEnd { get; set; }
    public long OrganizerId { get; set; }
    public bool IsActive { get; set; } = true;
    public List<long> AllowedSalesPeople { get; set; }
    public bool IsPrivate { get; set; }
}
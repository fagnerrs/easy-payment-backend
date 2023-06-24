namespace EP.Products.Domain.Models;

public class Rifa
{
    public long Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public long NumberStart { get; set; }
    public long NumberEnd { get; set; }
    public long CreatedbyUserId { get; set; }
    public bool IsActive { get; set; } = true;
    public List<RifaSalesPerson>? AllowedSalesPeople { get; set; }
    public List<RifaSoldNumber>? SoldNumbers { get; set; }
    public bool IsPublic { get; set; }
    public decimal Price { get; set; }
    public decimal SalesCommissionTax { get; set; } 
}
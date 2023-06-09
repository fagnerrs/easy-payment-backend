namespace EP.Products.Domain.Models;

public class RifaOrder
{
    public long Id { get; set; }
    public long RifaId { get; set; }
    public long SalesPersonId { get; set; }
    public List<int> Numbers { get; set; }
    public DateTime BuyDate { get; set; }
    public PaymentType PaymentType { get; set; }
    public Customer Customer { get; set; }
    public string Observation { get; set; }
}
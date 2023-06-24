namespace EP.Products.Domain.Models;

public class Customer
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string CNPJ { get; set; }
    public string CPF { get; set; }
    public long Id { get; set; }
}
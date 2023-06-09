namespace EP.User.Domain.Models;

public class PixPayment
{
    public PixTypes Types { get; set; }
    public string Value { get; set; }
    public BankAccount BankAccount { get; set; }
}
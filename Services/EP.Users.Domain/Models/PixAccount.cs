namespace EP.Users.Domain.Models;

public class PixAccount
{
    public long UserId { get; set; }
    public PixTypes Types { get; set; }
    public string Value { get; set; }
    public PixBankAccount BankAccount { get; set; }
}
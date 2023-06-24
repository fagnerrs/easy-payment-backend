namespace EP.Users.Domain.Models;

public class RifaBankAccount
{
    public long RifaId { get; set; }
    public string BankId { get; set; }
    public string BankAgency { get; set; }
    public string AccountNumber { get; set; }    
    public string AccountName { get; set; }
}
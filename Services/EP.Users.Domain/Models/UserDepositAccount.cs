namespace EP.Users.Domain.Models;

public class UserDepositAccount 
{
    public PixAccount Pix { get; set; }
    public BankAccount DepositBankAccount { get; set; }
    public long UserId { get; set; }
}
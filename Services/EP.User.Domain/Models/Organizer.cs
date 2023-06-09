using EP.Shared.Domain.Models;

namespace EP.User.Domain.Models;

public class Organizer : Person
{
    public DepositTypes DepositType { get; set; }
    public PixPayment Pix { get; set; }
    public BankAccount BankAccount { get; set; }
}
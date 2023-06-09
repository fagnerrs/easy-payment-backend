namespace EP.User.Domain.Models;

public abstract class Person
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string RG { get; set; }
    public string CPF { get; set; }
    public string CNPJ { get; set; }
    public string ContactPerson { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
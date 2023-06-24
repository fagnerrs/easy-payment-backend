namespace EP.Products.Domain.Exceptions;

public class RifaOrderException :Exception
{
    public RifaOrderException(string msg)
        :base(msg)
    {
    }
}
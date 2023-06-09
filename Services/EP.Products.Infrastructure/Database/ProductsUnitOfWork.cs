using EP.Products.Domain.Services.Interfaces;
using EP.Shared.Infrastructure.EntityFramework;

namespace EP.Products.Infrastructure.Database;

public class ProductsUnitOfWork : UnitOfWork<ProductsContext>, IProductUnitOfWork
{
    public ProductsUnitOfWork(ProductsContext context) : base(context)
    {
    }
}
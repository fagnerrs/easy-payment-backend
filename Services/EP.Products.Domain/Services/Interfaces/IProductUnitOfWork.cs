using EP.Shared.Domain.EntityFramework;

namespace EP.Products.Domain.Services.Interfaces;

public interface IProductUnitOfWork
{
    Task<long> Save();
    IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class;
}
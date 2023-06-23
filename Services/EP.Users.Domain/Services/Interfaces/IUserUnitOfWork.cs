using EP.Shared.Domain.EntityFramework;

namespace EP.Users.Domain.Services.Interfaces;

public interface IUserUnitOfWork
{
    Task<long> Save();
    IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class;
}
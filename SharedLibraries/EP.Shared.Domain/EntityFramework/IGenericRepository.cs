using System.Linq.Expressions;

namespace EP.Shared.Domain.EntityFramework;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetEntityQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    Task<TEntity> GetByIdAsync(long id);
    TEntity Add(TEntity entity);
    void Remove(TEntity entityToDelete);
    void Update(TEntity entityToUpdate);
}
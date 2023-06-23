using System.Linq.Expressions;
using EP.Shared.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EP.Shared.Infrastructure.EntityFramework;

public class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        private readonly TContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(TContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetEntityQueryable(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public async Task<TEntity> GetByIdAsync(long id) => await dbSet.FindAsync(id);

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void Update(TEntity entityToUpdate)
        {
            var entry = context.Entry(entityToUpdate);

            if (entry.State == EntityState.Unchanged)
                entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entityToDelete)
        {
            dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);
        }
        
        public async Task Remove(long id)
        {
            var entityToDelete = await GetByIdAsync(id);
            dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);
        }
    }
    
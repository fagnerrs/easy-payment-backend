using EP.Shared.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EP.Shared.Infrastructure.EntityFramework;

public class UnitOfWork<TContext> :  IDisposable where TContext : DbContext
{
    private bool disposed = false;

    private readonly TContext context;

    public UnitOfWork(TContext context)
    {
        this.context = context;
    }

    public IGenericRepository<TEntity> GetGenericRepository<TEntity>() where TEntity : class => new GenericRepository<TContext, TEntity>(context);

    public async Task<long> Save() => await context.SaveChangesAsync();

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

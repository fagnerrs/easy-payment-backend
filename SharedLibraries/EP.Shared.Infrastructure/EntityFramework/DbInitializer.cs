using Microsoft.EntityFrameworkCore;

namespace EP.Shared.Infrastructure.EntityFramework;

public class DbInitializer<T> where T : DbContext
{
    private readonly T context;
    public DbInitializer(T context)
    {
        this.context = context;
    }

    public void Run()
    {
        context.Database.EnsureCreated();
    }
}
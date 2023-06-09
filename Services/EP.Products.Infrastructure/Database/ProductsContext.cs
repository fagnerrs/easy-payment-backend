using EP.Products.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EP.Products.Infrastructure.Database;

public class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions<ProductsContext> options)
        : base(options)
    {}
    public DbSet<Rifa> Rifas { get; set; }
    public DbSet<RifaOrder> RifaOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rifa>().HasKey(p => p.Id);
        modelBuilder.Entity<RifaOrder>().HasKey(p => p.Id);
        
        base.OnModelCreating(modelBuilder);
    }
}
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
    public DbSet<RifaSoldNumber> RifaOrderSoldNumbers { get; set; }
    public DbSet<RifaSalesPerson> RifaSalesPeople { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasKey(p => p.Id);
        modelBuilder.Entity<RifaSoldNumber>().HasKey(p => p.Id);
        modelBuilder.Entity<RifaSalesPerson>().HasKey(p => new {p.RifaId, p.SalesPersonId });

        modelBuilder.Entity<Rifa>(
            ob =>
            {
                ob.Property(p => p.Id);
                ob.HasMany(o => o.AllowedSalesPeople)
                    .WithOne(o => o.Rifa)
                    .HasForeignKey(o=>o.RifaId)
                    .IsRequired(false);
                ob.HasMany(o => o.SoldNumbers)
                    .WithOne(o => o.Rifa)
                    .HasForeignKey(o=>o.RifaId)
                    .IsRequired(false);
            });

        modelBuilder.Entity<RifaOrder>(
            ob =>
            {
                ob.Ignore(p => p.Customer);
                ob.HasKey(p => p.Id);
                ob.HasMany(o => o.SoldNumbers)
                    .WithOne(o => o.RifaOrder)
                    .HasForeignKey(o=>o.RifaOrderId)
                    .IsRequired();
            });

        base.OnModelCreating(modelBuilder);
    }
}
using EP.Shared.Domain.Models;
using EP.User.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EP.User.Infrastructure.Database;


public class UserContext : DbContext
{
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {}
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<SalesPerson> SalesPeople { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BankAccount>();
            modelBuilder.Ignore<PixPayment>();
            modelBuilder.Entity<Organizer>().HasKey(p => p.Id);
            modelBuilder.Entity<SalesPerson>().HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
}
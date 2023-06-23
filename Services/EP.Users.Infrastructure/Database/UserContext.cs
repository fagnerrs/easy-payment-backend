using EP.Users.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EP.Users.Infrastructure.Database;
public class UserContext : DbContext
{
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().HasKey(p => p.UserId);
            modelBuilder.Entity<PixBankAccount>().HasKey(p => p.UserId);
            modelBuilder.Entity<PixAccount>(
                ob =>
                {
                    ob.HasKey(p => p.UserId);
                    ob.HasOne(o => o.BankAccount).WithOne()
                        .HasForeignKey<PixBankAccount>(o => o.UserId);
                });
            
            modelBuilder.Entity<UserDepositAccount>(
                ob =>
                {
                    
                    ob.HasKey(p => p.UserId);
                    ob.HasOne(o => o.Pix).WithOne()
                        .HasForeignKey<PixAccount>(o => o.UserId);
                    ob.HasOne(o => o.DepositBankAccount).WithOne()
                        .HasForeignKey<BankAccount>(o => o.UserId);
                    
                });
    
            
            base.OnModelCreating(modelBuilder);
        }
}
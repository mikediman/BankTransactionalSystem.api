using BankTransactionalSystem.Implementation.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace BankTransactionalSystem.Implementation.Database
{
    public class TransactionalSystemDbContext : DbContext
    {
        public TransactionalSystemDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>()
                .ToTable("Card");

            modelBuilder.Entity<Card>()
                .HasIndex(c => c.CardOwner)
                .IsUnique();

            modelBuilder.Entity<Limit>()
                .ToTable("Limit");
        }
    }
}

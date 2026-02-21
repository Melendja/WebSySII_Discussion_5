using Microsoft.EntityFrameworkCore;
using CustomerCRUD.Models;

namespace CustomerCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FirstName).HasColumnName("firstName").HasColumnType("varchar(100)").IsRequired();
                entity.Property(e => e.LastName).HasColumnName("lastName").HasColumnType("varchar(100)").IsRequired();
            });
        }
    }
}

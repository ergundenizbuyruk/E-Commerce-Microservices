using ECommerce.Services.Order.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Order.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Models.Order>()
                .HasMany(s => s.ProductOrders)
                .WithOne(s => s.Order)
                .HasForeignKey(s => s.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasKey(s => new { s.OrderId, s.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}

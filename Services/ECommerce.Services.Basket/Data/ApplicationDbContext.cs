using ECommerce.Services.Basket.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Basket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Models.Basket>()
                .HasKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

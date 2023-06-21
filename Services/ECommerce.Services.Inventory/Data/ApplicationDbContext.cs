using ECommerce.Services.Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services.Inventory.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
    }
}

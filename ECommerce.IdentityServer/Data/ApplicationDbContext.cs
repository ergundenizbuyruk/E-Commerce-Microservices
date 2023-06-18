using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
    {

        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }
    }
}

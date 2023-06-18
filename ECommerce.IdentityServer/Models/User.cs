using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServer.Models
{
    public class User : IdentityUser<Guid>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }
        public List<Address> Addresses { get; set; }
    }
}

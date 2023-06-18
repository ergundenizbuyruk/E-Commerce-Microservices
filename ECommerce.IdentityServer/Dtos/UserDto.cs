using ECommerce.IdentityServer.Models;

namespace ECommerce.IdentityServer.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }
    }
}

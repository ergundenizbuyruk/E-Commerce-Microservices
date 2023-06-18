using ECommerce.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.IdentityServer.Dtos
{
    public class UpdateUserDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }
    }
}

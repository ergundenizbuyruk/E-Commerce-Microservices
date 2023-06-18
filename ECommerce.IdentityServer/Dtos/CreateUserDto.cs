using ECommerce.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.IdentityServer.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        public string PasswordConfirm { get; set; }
    }
}

﻿using ECommerce.IdentityServer.Models;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.IdentityServer.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

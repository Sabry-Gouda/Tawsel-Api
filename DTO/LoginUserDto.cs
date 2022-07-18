﻿using System.ComponentModel.DataAnnotations;

namespace tawsel.DTO
{
    public class LoginUserDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tawsel.models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(255)]
        public string PasswordSalt { get; set; }

        public bool Active { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }

        public CustomRole Role { get; set; }

        public virtual List<Order> Order { get; set; }= new List<Order>();
    }
}

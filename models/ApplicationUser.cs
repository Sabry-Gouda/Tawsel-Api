using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace tawsel.models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<Order> Order { get; set; }= new List<Order>();
    }
}

using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class CustomRole : IdentityRole
    {
        [JsonIgnore]
        public  List<PremissionRoleController> PremissionRoleControllers { get; set; }= new List<PremissionRoleController>();
    }
}

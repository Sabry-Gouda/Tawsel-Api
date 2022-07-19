using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class Premssion
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Permission Group Name is Required")]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<PremissionRoleController> PremissionRoleControllers { get; set; } = new List<PremissionRoleController>();
    }
}

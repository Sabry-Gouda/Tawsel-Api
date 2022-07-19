using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class PremissionRoleController
    {
        [ForeignKey("page")]
        public int PageId { get; set; }

        [ForeignKey("role")]
        public string RoleID { get; set; }

        [ForeignKey("permission")]
        public int permissionId { get; set; }
        
        [JsonIgnore]
        public page page { get; set; }

        [JsonIgnore]
        public CustomRole role { get; set; }

        [JsonIgnore]
        public Premssion permission { get; set; }




    }
}

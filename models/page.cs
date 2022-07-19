using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class page
    {
        public page()
        {
            permissions = new List<PremissionRoleController>();
        }
        public int id { get; set; }
        public string name { get; set; }


        [JsonIgnore]
        public List<PremissionRoleController> permissions { get; set; }
    }
}

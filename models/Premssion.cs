using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class Premssion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]

        public List<PremissionRoleController> PremissionRoleControllers { get; set; }= new List<PremissionRoleController>();
    }
}

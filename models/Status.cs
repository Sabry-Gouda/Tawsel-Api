using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]

        public List<Order> Order { get; set; } = new List<Order>();
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class ShippingType
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int Cost { get; set; }

        [JsonIgnore]
        public List<Order> orders { get; set; }
    }
}

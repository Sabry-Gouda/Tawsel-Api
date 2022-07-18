using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class CashType
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public List<Order> orders { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class OrderTypes
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName ="varchar(20)")]
        public string name { get; set; }

        [JsonIgnore]
        public List<Order> orders { get; set; }

    }
}

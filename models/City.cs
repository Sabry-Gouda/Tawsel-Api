using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CostPerCity { get; set; }
        [ForeignKey("state")]
        public int stateId { get; set; }
        [JsonIgnore]
        public  List<Branches> Branches { get; set; } = new List<Branches>();
        [JsonIgnore]
        public  List<Order> Order { get; set; } = new List<Order>();
        [JsonIgnore]
        public State state { set; get; }

        [JsonIgnore]

        public List<Client> Clients { get; set; } = new List<Client>();
    }
}

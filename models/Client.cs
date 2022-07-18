using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        [ForeignKey("state")]
        public int stateId { get; set; }
        [ForeignKey("city")]

        public int cityId { get; set; }

        [JsonIgnore]
        public State state { get; set; }
        [JsonIgnore]

        public City city { get; set; }
        [JsonIgnore]

        public List<Order> orders { get; set; }
    }
}

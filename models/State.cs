using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool status { get; set; }

        [JsonIgnore]

        public List<Order> Order { get; set; } = new List<Order>();
        [JsonIgnore]

        public List<City> Cities { get; set; } = new List<City>();

        [JsonIgnore]

        public List<Client> Clients { get; set; } = new List<Client>();
    }
}

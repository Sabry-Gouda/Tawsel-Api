using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class Branches
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime createdDate  { get; set; }

        public bool status { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        [JsonIgnore]
        public City City { get; set; }
    }
}

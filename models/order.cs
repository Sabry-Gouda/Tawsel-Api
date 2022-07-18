using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace tawsel.models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string serialNumber { get; set; }

        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal weight { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        [JsonIgnore]
        public State State { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("client")]
        public int ClientId { get; set; }

        [ForeignKey("shiping")]
        public int ShipId { get; set; }

        [ForeignKey("cash")]
        public int CashId { get; set; }

        [JsonIgnore]
        public City City { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [ForeignKey("orderTypes")]
        public int orderType { get; set; }

        [JsonIgnore]
        public Status Status { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

        [JsonIgnore]

        public ShippingType shiping { get; set; }
        [JsonIgnore]

        public CashType cash { get; set; }

        [JsonIgnore]

        public Client client { get; set; }
        [JsonIgnore]

        public List<product> products { get; set; }
        [JsonIgnore]

        public OrderTypes orderTypes { get; set; }



    }
}

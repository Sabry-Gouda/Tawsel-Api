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
        public Order()
        {
            products = new List<product>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Order Serial Number is Required")]
        public string serialNumber { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("client")]
        public int ClientId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public string street { get; set; }

        public bool isShippableToVillage { get; set; }

        [ForeignKey("shiping")]
        public int ShipId { get; set; }

        [ForeignKey("cash")]
        public int CashId { get; set; }

        [ForeignKey("orderTypes")]
        public int orderType { get; set; }

        [ForeignKey("Branch")]
        public int branchId { get; set; }

        public List<product> products { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="total Cost is Required")]
        public decimal totalCost { get; set; }
        
        [Required(AllowEmptyStrings =false,ErrorMessage ="total weight Number is Required")]
        public decimal totalWeight { get; set; }

        [ForeignKey("Trader")]
        public int traderId { get; set; }



        [JsonIgnore]
        public State State { get; set; }
        
        [JsonIgnore]
        public Branches Branch { get; set; }

        [JsonIgnore]
        public City City { get; set; }

        [JsonIgnore]
        public Status Status { get; set; }

        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }

        [JsonIgnore]
        public ShippingType shiping { get; set; }

        [JsonIgnore]
        public CashType cash { get; set; }

        [JsonIgnore]
        public Client client { get; set; }

        [JsonIgnore]
        public OrderTypes orderTypes { get; set; }

        [JsonIgnore]
        public Trader Trader { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tawsel.DTO
{
    public class NewOrderDto
    {
        public string UserId { get; set; }

        public int StatusId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Order Serial Number is Required")]
        public string serialNumber { get; set; }

        public DateTime date { get; set; }

        public clientDto customerData { get; set; }

        public int stateId { get; set; }

        public int cityId { get; set; }

        public string street { get; set; }

        public bool isShippableToVillage { get; set; }

        public int shipmentMethodId { get; set; }

        public int paymentMethodId { get; set; }

        public int orderType { get; set; }

        public int branchId { get; set; }

        public List<PorductDto> products { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "total Cost is Required")]
        public decimal totalCost { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "total weight Number is Required")]
        public decimal totalWeight { get; set; }

        public TraderDto trader { get; set; }
    }
}

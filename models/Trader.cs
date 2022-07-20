using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tawsel.models
{
    public class Trader
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Trader Phone is required")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Trader Address is required")]
        public string Address { get; set; }

        public List<Order> orders { get; set; }

        public Trader()
        {
            orders = new List<Order>();
        }
    }
}

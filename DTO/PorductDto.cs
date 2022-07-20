using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tawsel.DTO
{
    public class PorductDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is Required")]
        public string name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "quantity is Required")]
        public int quantity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "weight is Required")]
        public decimal weight { get; set; }
    }
}

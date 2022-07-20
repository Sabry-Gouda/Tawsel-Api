using System.ComponentModel.DataAnnotations;

namespace tawsel.DTO
{
    public class TraderDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Trader Phone is required")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Trader Address is required")]
        public string Address { get; set; }
    }
}

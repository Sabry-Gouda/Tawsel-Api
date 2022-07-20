using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace tawsel.models
{
    public class product
    {
        [Key]
        public int id { get; set; }
        
        [Column(TypeName ="varchar(20)")]
        public string name { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage = "quantity is Required")]
        public int quantity { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "weight is Required")]
        public decimal weight { get; set; }

        [ForeignKey("order")]
        public int orderId { get; set; }

        [JsonIgnore]
        public Order order { get; set; }

    }
}

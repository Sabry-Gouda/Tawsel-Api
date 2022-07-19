using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using tawsel.models;

namespace tawsel.DTO
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "FullName is Rquired")]
        [RegularExpression(@"^[a-z|A-Z]+$", ErrorMessage = "Invalid FullName")]
        public string Full_Name { get; set; }

        [Required(ErrorMessage = "UserName is Rquired")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Rquired")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Permission is Rquired")]
        [ForeignKey("Role")]
        public string roleId { get; set; }

        [Required(ErrorMessage = "Email is Rquired")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [JsonIgnore]
        public CustomRole Role { get; set; }
    }
}

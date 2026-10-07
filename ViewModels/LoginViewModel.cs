using System.ComponentModel.DataAnnotations;

namespace EasyRepair.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email requested!")]
        [EmailAddress(ErrorMessage = "Insert a valid email!")]
        [RegularExpression(@"^[a-zA-Z]+(?:[a-zA-Z0-9]+)@[a-zA-Z]+(?:[a-zA-Z0-9]+).[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}

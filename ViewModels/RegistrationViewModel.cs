using System.ComponentModel.DataAnnotations;

namespace EasyRepair.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Wrong email format!")]
        [RegularExpression(@"^[a-zA-Z]+(?:[-._][a-zA-Z0-9]+)@[a-zA-Z]+(?:[-._][a-zA-Z0-9]+).[a-zA-Z]{2,}$", ErrorMessage = "Only . and - are permitted as special characters!")]
        public string? Email { set; get; }

        [Required(ErrorMessage = "Name is required!")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Surname musto contain only letters")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Address is Required!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Address Must contain numbers and letters only!")]
        public string? Address { set; get; }

        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password length must be between 8 and 100!")]
        public string? Password { set; get; }

        [Required(ErrorMessage = "You need to repeat password!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are different!")]
        public string? RepeatPassword { set; get; }
    }
}

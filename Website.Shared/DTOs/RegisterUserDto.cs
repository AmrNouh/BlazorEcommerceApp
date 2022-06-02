using System.ComponentModel.DataAnnotations;

namespace Website.Shared.DTOs
{
    public class RegisterUserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is Requird")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Requird")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a valid Email Address")]
        public string? Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Requird")]
        [DataType(DataType.Password, ErrorMessage = "Please Enter a valid Password")]
        public string? Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords don't Match")]
        public string? ConfirmPassword { get; set; }
    }
}
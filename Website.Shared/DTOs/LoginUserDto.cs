using System.ComponentModel.DataAnnotations;

namespace Website.Shared.DTOs
{
    public class LoginUserDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your UserName")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter your Password")]
        public string? Password { get; set; }
    }
}
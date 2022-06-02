using System.ComponentModel.DataAnnotations;

namespace Website.Shared.DTOs
{
    public class RoleDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Role Name is Required")]
        public string? RoleName { get; set; }
    }
}
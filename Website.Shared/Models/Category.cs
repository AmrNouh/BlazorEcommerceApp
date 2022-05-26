using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        public List<Product>? Products { get; set; } = new List<Product>();
    }
}
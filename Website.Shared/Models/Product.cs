using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Product Name")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        [Range(1, 10000, ErrorMessage = "Product Price Must be between 1$ to 10000$")]
        [Column(TypeName = "decimal(8,3)")]
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Product Description")]
        [Column(TypeName = "nvarchar(200)")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Product Image")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Image { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please Select Product Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
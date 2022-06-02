using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Product Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        [Range(1, 10000, ErrorMessage = "Product Price Must be between 1$ to 10000$")]
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Product Description")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Product Image")]
        public string? Image { get; set; }

        [ForeignKey("Category")]
        [Required(ErrorMessage = "Please Select Product Category")]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}

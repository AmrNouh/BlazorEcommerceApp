using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website.Shared.Models
{
    public class CartProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int OrderCount { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}

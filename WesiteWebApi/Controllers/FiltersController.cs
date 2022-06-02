using Microsoft.AspNetCore.Mvc;
using Website.Shared.DTOs;
using Website.Shared.Models;
using WesiteWebApi.Repositories.Products;

namespace WesiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public FiltersController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetFilteredProducts(int categoryId)
        {
            List<Product>? products = await _productRepository.FilterByCategoryIdAsync(categoryId);
            List<ProductDto> productsList = new List<ProductDto>();
            if (products is null)
            {
                return NotFound();
            }
            else
            {
                productsList = products.Select(x => new ProductDto { Id = x.Id, Name = x.Name, Description = x.Description, Price = x.Price, CategoryId = x.CategoryId, Image = x.Image, CategoryName = x.Category.Name }).ToList();
            }
            return productsList;
        }
    }
}

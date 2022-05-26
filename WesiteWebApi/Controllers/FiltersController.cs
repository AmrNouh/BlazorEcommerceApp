using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetFilteredProducts(int categoryId)
        {
            List<Product>? products = await _productRepository.FilterByCategoryIdAsync(categoryId);
            return products is null ? NotFound() : products;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Shared.Models;
using WesiteWebApi.Repositories.Categories;

namespace WesiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            List<Category>? categories = await _categoryRepository.GetAllAsync();
            return categories is null ? NotFound() : categories;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            Category? category = await _categoryRepository.GetByIdAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int affectedRow = await _categoryRepository.UpdateAsync(id, category);
                    return affectedRow switch
                    {
                        0 => NotFound(),
                        -1 => BadRequest(),
                        _ => NoContent(),
                    };
                }
                catch (Exception ex)
                {
                    // Log Exception
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }


        }

        // POST: api/Categories
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                int affectedRow = await _categoryRepository.InsertAsync(category);
                return affectedRow switch
                {
                    0 => BadRequest("Error"),
                    _ => CreatedAtAction("GetCategory", new { id = category.Id }, category),
                };
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            int affectedRow = await _categoryRepository.DeleteAsync(id);
            if (affectedRow == 0)
            {
                return NotFound();
            }
            else
            {
                return NoContent();
            }

        }


    }
}

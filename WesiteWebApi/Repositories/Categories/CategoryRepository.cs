using Microsoft.EntityFrameworkCore;
using Website.Shared.Models;
using WesiteWebApi.Models;

namespace WesiteWebApi.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebsiteDbContext _websiteDbContext;

        public CategoryRepository(WebsiteDbContext websiteDbContext)
        {
            _websiteDbContext = websiteDbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            Category category = await GetByIdAsync(id);
            if (category is not null)
            {
                _websiteDbContext.Categories.Remove(category);
                return await _websiteDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Category>> GetAllAsync() => await _websiteDbContext.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(int id) => await _websiteDbContext.Categories.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<int> InsertAsync(Category entity)
        {
            if (entity is not null)
            {
                _websiteDbContext.Categories.Add(entity);
                return await _websiteDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateAsync(int id, Category entity)
        {
            if (id != entity.Id)
            {
                return -1;
            }

            Category oldCategory = await GetByIdAsync(id);
            if (oldCategory is not null)
            {
                oldCategory.Name = entity.Name;
                try
                {
                    return await _websiteDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(id))
                    {
                        return 0;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return 0;
        }

        private bool CategoryExists(int id) => (_websiteDbContext.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
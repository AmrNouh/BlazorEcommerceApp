using Microsoft.EntityFrameworkCore;
using Website.Shared.Models;
using WesiteWebApi.Models;

namespace WesiteWebApi.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebsiteDbContext _websiteDbContext;

        public ProductRepository(WebsiteDbContext websiteDbContext)
        {
            _websiteDbContext = websiteDbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            Product product = await GetByIdAsync(id);
            if (product is not null)
            {
                _websiteDbContext.Products.Remove(product);
                return await _websiteDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<List<Product>> FilterByCategoryIdAsync(int categoryId) => await _websiteDbContext.Products.Include<Product>("Category").Where(x => x.CategoryId == categoryId).ToListAsync();

        public async Task<List<Product>> GetAllAsync() => await _websiteDbContext.Products.Include<Product>("Category").ToListAsync();

        public async Task<Product> GetByIdAsync(int id) => await _websiteDbContext.Products.Include<Product>("Category").FirstOrDefaultAsync(p => p.Id == id);

        public async Task<int> InsertAsync(Product entity)
        {
            if (entity is not null)
            {
                _websiteDbContext.Products.Add(entity);
                return await _websiteDbContext.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> UpdateAsync(int id, Product entity)
        {
            if (id != entity.Id)
            {
                return -1;
            }

            Product oldProduct = await GetByIdAsync(id);
            if (oldProduct is not null)
            {
                oldProduct.Name = entity.Name;
                oldProduct.Description = entity.Description;
                oldProduct.CategoryId = entity.CategoryId;
                oldProduct.Price = entity.Price;
                oldProduct.Image = entity.Image;
                try
                {
                    await _websiteDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(id))
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

        private bool ProductExists(int id) => (_websiteDbContext.Products?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
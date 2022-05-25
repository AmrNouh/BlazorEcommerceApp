using Website.Shared.Models;

namespace BlazorAppDay02.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        public Task<int> DeleteAsync(int id) => throw new NotImplementedException();
        public Task<List<Product>> FilterByCategoryId(int categoryId) => throw new NotImplementedException();
        public Task<List<Product>> GetAllAsync() => throw new NotImplementedException();
        public Task<Product> GetByIdAsync(int id) => throw new NotImplementedException();
        public Task<int> InsertAsync(Product entity) => throw new NotImplementedException();
        public Task<int> UpdateAsync(int id, Product entity) => throw new NotImplementedException();
    }
}

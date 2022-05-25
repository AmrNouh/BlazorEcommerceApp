using Website.Shared.Models;

namespace BlazorAppDay02.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<int> DeleteAsync(int id) => throw new NotImplementedException();
        public Task<List<Category>> GetAllAsync() => throw new NotImplementedException();
        public Task<Category> GetByIdAsync(int id) => throw new NotImplementedException();
        public Task<int> InsertAsync(Category entity) => throw new NotImplementedException();
        public Task<int> UpdateAsync(int id, Category entity) => throw new NotImplementedException();
    }
}

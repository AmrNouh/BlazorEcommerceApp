using System.Net.Http.Json;
using Website.Shared.Models;

namespace BlazorAppDay02.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string categoryBaseUrl = "/api/Categories";
        public CategoryRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> DeleteAsync(int id) => throw new NotImplementedException();

        public async Task<List<Category>> GetAllAsync() => await _httpClient.GetFromJsonAsync<List<Category>>(categoryBaseUrl);

        public async Task<Category> GetByIdAsync(int id) => throw new NotImplementedException();
        public async Task<int> InsertAsync(Category entity) => throw new NotImplementedException();
        public async Task<int> UpdateAsync(int id, Category entity) => throw new NotImplementedException();
    }
}

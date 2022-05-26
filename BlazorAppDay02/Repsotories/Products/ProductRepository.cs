using System.Net.Http.Json;
using Website.Shared.Models;

namespace BlazorAppDay02.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string productBaseUrl = "/api/Products";
        private readonly string filterProductBaseUrl = "/api/Filters";

        public ProductRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> DeleteAsync(int id)
        {
            HttpResponseMessage httpResponse = await _httpClient.DeleteAsync($"{productBaseUrl}/{id}");
            return httpResponse.IsSuccessStatusCode ? 1 : -1;
        }

        public async Task<List<Product>> FilterByCategoryIdAsync(int categoryId) => await _httpClient.GetFromJsonAsync<List<Product>>($"{filterProductBaseUrl}/{categoryId}");

        public async Task<List<Product>> GetAllAsync() => await _httpClient.GetFromJsonAsync<List<Product>>(productBaseUrl);

        public async Task<Product> GetByIdAsync(int id) => await _httpClient.GetFromJsonAsync<Product>($"{productBaseUrl}/{id}");

        public async Task<int> InsertAsync(Product entity)
        {
            HttpResponseMessage httpResponse = await _httpClient.PostAsJsonAsync<Product>(productBaseUrl, entity);
            return httpResponse.IsSuccessStatusCode ? 1 : -1;
        }

        public async Task<int> UpdateAsync(int id, Product entity)
        {
            HttpResponseMessage httpResponse = await _httpClient.PutAsJsonAsync<Product>($"{productBaseUrl}/{id}", entity);
            return httpResponse.IsSuccessStatusCode ? 1 : -1;
        }
    }
}

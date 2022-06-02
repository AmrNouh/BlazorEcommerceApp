using Website.Shared.DTOs;
using Website.Shared.Models;
using Website.Shared.Repositories;

namespace BlazorAppDay02.Repositories.Products
{
    public interface IProductRepository
    {

        Task<List<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, Product entity);
        Task<int> DeleteAsync(int id);
        Task<int> InsertAsync(Product entity);
        Task<List<ProductDto>> FilterByCategoryIdAsync(int categoryId);
    }
}

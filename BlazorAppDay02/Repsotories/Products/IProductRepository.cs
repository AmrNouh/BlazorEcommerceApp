using Website.Shared.Models;
using Website.Shared.Repositories;

namespace BlazorAppDay02.Repositories.Products
{
    public interface IProductRepository : IGeneralRepository<Product>
    {
        Task<List<Product>> FilterByCategoryId(int categoryId);
    }
}

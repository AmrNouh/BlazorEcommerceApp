using Website.Shared.Models;
using Website.Shared.Repositories;

namespace WesiteWebApi.Repositories.Products
{
    public interface IProductRepository : IGeneralRepository<Product>
    {
        Task<List<Product>> FilterByCategoryIdAsync(int categoryId);
    }
}
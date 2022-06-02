using BlazorAppDay02.Repositories.Products;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ViewAllProducts
    {
        [Inject]
        private IProductRepository? ProductRepository { get; set; }

        public List<ProductDto>? Products { get; set; }
        public int CategoryId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (ProductRepository is not null)
            {
                Products = await ProductRepository.GetAllAsync();
            }
            await base.OnInitializedAsync();
        }

        public async void FilterProducts()
        {
            if (ProductRepository is not null)
            {
                if (CategoryId != 0)
                {

                    Products = await ProductRepository.FilterByCategoryIdAsync(CategoryId);

                }
                else
                {
                    Products = await ProductRepository.GetAllAsync();
                }
            }
        }

        private async void ProductDeletedHandler(int productId)
        {
            Products = await ProductRepository.GetAllAsync();
        }
    }
}

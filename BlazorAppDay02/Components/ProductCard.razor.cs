using BlazorAppDay02.Repositories.Products;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ProductCard
    {
        [Parameter]
        public ProductDto Product { get; set; }

        [Parameter]
        public EventCallback<int> OnProductDeleted { set; get; } 

        [Inject]
        private IProductRepository? ProductRepository { get; set; }

        private async void DeleteProduct()
        {
            await ProductRepository.DeleteAsync(Product.Id);
            await OnProductDeleted.InvokeAsync(Product.Id);
        }
    }
}

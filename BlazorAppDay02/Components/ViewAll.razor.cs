using BlazorAppDay02.Repositories.Categories;
using BlazorAppDay02.Repositories.Products;
using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ViewAll
    {
        [Inject]
        private IProductRepository? ProductRepository { get; set; }
        [Inject]
        private ICategoryRepository? CategoryRepository { get; set; }

        public List<Category>? Categories { get; set; }
        public List<Product>? Products { get; set; }
        public int CategoryId { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (CategoryRepository is not null && ProductRepository is not null)
            {
                Categories = await CategoryRepository.GetAllAsync();
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
    }
}

using BlazorAppDay02.Repositories.Categories;
using BlazorAppDay02.Repositories.Products;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class Edit
    {
        [Parameter]
        public int Id { get; set; }
        public ProductDto? Product { get; set; }
        public List<Category> Categories { get; set; } = new();

        [Inject]
        private IProductRepository? ProductRepository { get; set; }
        [Inject]
        private ICategoryRepository? CategoryRepository { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductRepository is not null && CategoryRepository is not null)
            {
                Product = await ProductRepository.GetByIdAsync(Id);
                Categories = await CategoryRepository.GetAllAsync();
            }
            await base.OnInitializedAsync();
        }
    }
}

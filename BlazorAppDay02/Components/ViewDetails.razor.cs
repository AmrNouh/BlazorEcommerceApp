using BlazorAppDay02.Repositories.Categories;
using BlazorAppDay02.Repositories.Products;
using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ViewDetails
    {
        [Parameter]
        public int Id { get; set; }
        public Product? Product { get; set; }

        [Inject]
        private IProductRepository? ProductRepository { get; set; }
        [Inject]
        private ICategoryRepository? CategoryRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ProductRepository is not null)
            {
                this.Product = await ProductRepository.GetByIdAsync(Id);
            }
            await base.OnInitializedAsync();
        }
    }
}

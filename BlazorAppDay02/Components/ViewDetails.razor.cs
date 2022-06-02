using BlazorAppDay02.Repositories.Categories;
using BlazorAppDay02.Repositories.Products;
using BlazorAppDay02.Repsotories.LocalStorageServices;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ViewDetails
    {
        [Parameter]
        public int Id { get; set; }
        public ProductDto? Product { get; set; }

        [Inject]
        private IProductRepository? ProductRepository { get; set; }

        [Inject]
        private ILocalStorageService? LocalStorageService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

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

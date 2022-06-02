using BlazorAppDay02.Repositories.Categories;
using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class FilterPanel
    {
        [Inject]
        private ICategoryRepository? CategoryRepository { get; set; }

        public List<Category>? Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if (CategoryRepository is not null)
            {
                Categories = await CategoryRepository.GetAllAsync();
            }
            await base.OnInitializedAsync();
        }

    }
}

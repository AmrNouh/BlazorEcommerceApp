using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class Edit
    {
        [Parameter]
        public int Id { get; set; }
        public Product? Product { get; set; }


        //protected override void OnInitializedA()
        //{
        //    base.OnInitialized();
        //    this.Product =  productRepository.GetByIdAsync(Id);
        //}

        public void SaveProduct()
        {

        }
    }
}

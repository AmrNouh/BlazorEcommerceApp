using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ViewDetails
    {
        [Parameter]
        public int Id { get; set; }
        public Product? Product { get; set; }

        //protected override void OnInitialized()
        //{
        //    base.OnInitialized();
        //    this.Product = productRepository.GetById(Id);
        //}
    }
}

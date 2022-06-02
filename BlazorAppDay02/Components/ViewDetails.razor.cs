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

        private async Task AddToCart()
        {
            var cart = await LocalStorageService.GetItem<List<CartProduct>>("cart");
            if (cart == null)
            {
                cart = new List<CartProduct>();
                cart.Add(new CartProduct
                {
                    Id = Product.Id,
                    Name = Product.Name,
                    OrderCount = 1,
                    Price = Product.Price,
                    Image = Product.Image,
                    Category = Product.CategoryName
                });
            }else
            {
                var isExists = cart.Select(x => x.Id).Contains(Product.Id);
                if (isExists)
                {
                    var product = cart.FirstOrDefault(x => x.Id == Product.Id);
                    product.OrderCount++;

                }else
                {
                    cart.Add(new CartProduct
                    {
                        Id = Product.Id,
                        Name = Product.Name,
                        OrderCount = 1,
                        Price = Product.Price,
                        Image = Product.Image,
                        Category = Product.CategoryName
                    });
                }
            }
            await LocalStorageService.SetItem<List<CartProduct>>("cart",cart);
            NavigationManager.NavigateTo("ShoppingCart");
        }
    }
}

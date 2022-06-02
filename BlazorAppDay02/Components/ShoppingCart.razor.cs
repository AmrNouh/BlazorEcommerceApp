using BlazorAppDay02.Repsotories.LocalStorageServices;
using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ShoppingCart
    {
        [Inject]
        private ILocalStorageService? LocalStorageService { get; set; }

        public int ItemCount { get; set; } = 0;

        public List<CartProduct> CartItems { get; set; } = new List<CartProduct>();

        protected async override Task OnInitializedAsync()
        {
           CartItems = await LocalStorageService.GetItem<List<CartProduct>>("cart");

            await base.OnInitializedAsync();
        }

        private decimal GetItemsTotalPrice()
        {
            decimal ItemsTotalPrice = 0;
            if (CartItems is null)
            {
                return 0;
            }
            foreach (var item in CartItems)
            {
                ItemsTotalPrice += (item.Price * item.OrderCount);
                ItemCount++;
            }
            return ItemsTotalPrice;

        }

        private async void cartitemChangeHandler(List<CartProduct> cartProducts)
        {
            await LocalStorageService.RemoveItem("cart");
            CartItems = cartProducts;
            await LocalStorageService.SetItem("cart", CartItems);
        }

    }
}

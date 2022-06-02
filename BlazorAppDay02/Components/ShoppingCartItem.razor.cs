using BlazorAppDay02.Repsotories.LocalStorageServices;
using Microsoft.AspNetCore.Components;
using Website.Shared.Models;

namespace BlazorAppDay02.Components
{
    public partial class ShoppingCartItem
    {
        [Parameter]
        public CartProduct Item { get; set; } = new();

        [Inject]
        private ILocalStorageService LocalStorageService { get; set; }

        [Parameter]
        public EventCallback<List<CartProduct>> UpdateCartItems { set; get; }

        private void DecreaseOrederCount()
        {
            if (Item is not null)
            {
                if (Item.OrderCount > 1)
                {
                    Item.OrderCount--;
                }
            }

        }

        private void IncreaseOrderCount()
        {
            if (Item is not null)
            {
                Item.OrderCount++;
            }
        }

        private async void DelecteItemFromCart()
        {
            var cart = await LocalStorageService.GetItem<List<CartProduct>>("cart");
            if (cart is not null)
                cart.Remove(Item);

            await UpdateCartItems.InvokeAsync(cart);

        }
    }
}

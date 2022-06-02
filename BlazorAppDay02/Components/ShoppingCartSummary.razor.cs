using Microsoft.AspNetCore.Components;

namespace BlazorAppDay02.Components
{
    public partial class ShoppingCartSummary
    {
        [Parameter]
        public decimal ItemsPrice { get; set; }

        [Parameter]
        public int ItemCount { get; set; }
    }
}

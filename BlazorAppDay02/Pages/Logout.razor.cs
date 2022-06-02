using BlazorAppDay02.Repsotories.Accounts;
using Microsoft.AspNetCore.Components;

namespace BlazorAppDay02.Pages
{
    public partial class Logout
    {
        [Inject]
        public IAccountRepository AccountService { get; set; }

        protected override async void OnInitialized() => await AccountService.Logout();
    }
}

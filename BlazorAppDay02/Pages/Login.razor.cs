using BlazorAppDay02.Repsotories.Accounts;
using BlazorAppDay02.Repsotories.AlertServices;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;

namespace BlazorAppDay02.Pages
{
    public partial class Login
    {
        private LoginUserDto model = new LoginUserDto();
        private bool loading;

        [Inject]
        public IAccountRepository AccountService { get; set; }

        [Inject]
        public IAlertService AlertService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async void OnValidSubmit()
        {
            AlertService.Clear();
            loading = true;
            try
            {
                await AccountService.Login(model);
                NavigationManager.NavigateTo("Products");
            }
            catch (Exception ex)
            {
                AlertService.Error(ex.Message);
                loading = false;
            }
        }

    }
}

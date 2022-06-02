using BlazorAppDay02.Repsotories.Accounts;
using BlazorAppDay02.Repsotories.AlertServices;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;

namespace BlazorAppDay02.Pages
{
    public partial class Register
    {
        private RegisterUserDto model = new RegisterUserDto();
        private bool loading;

        [Inject]
        public IAccountRepository AccountService { get; set; }

        [Inject]
        public IAlertService AlertService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
    }
}

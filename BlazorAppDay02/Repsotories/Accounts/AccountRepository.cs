using BlazorAppDay02.Repsotories.HttpServices;
using BlazorAppDay02.Repsotories.LocalStorageServices;
using Microsoft.AspNetCore.Components;
using Website.Shared.DTOs;
using Website.Shared.Models;

namespace BlazorAppDay02.Repsotories.Accounts
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IHttpService _httpService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly string accountBaseUrl = "/api/Accounts";
        public User? User { get; private set; }
        private string _userKey = "user";

        public AccountRepository(IHttpService httpService, ILocalStorageService localStorageService,
            NavigationManager navigationManager)
        {
            _httpService = httpService;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }


        public async Task Login(LoginUserDto loginUserDto)
        {
            User = await _httpService.Post<User>($"{accountBaseUrl}/Login", loginUserDto);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("login");
        }

        public async Task Register(RegisterUserDto registerUserDto) => await _httpService.Post($"{accountBaseUrl}/Register", registerUserDto);
    }
}

using Microsoft.JSInterop;
using System.Text.Json;

namespace BlazorAppDay02.Repsotories.LocalStorageServices
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime _jsRuntime;
        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            string? json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            if (json is null)
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task RemoveItem(string key) => await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);

        public async Task SetItem<T>(string key, T value) => await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
    }
}

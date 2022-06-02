using BlazorAppDay02.Helpers;
using BlazorAppDay02.Repsotories.LocalStorageServices;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Website.Shared.Models;

namespace BlazorAppDay02.Repsotories.HttpServices
{
    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private ILocalStorageService _localStorageService;
        private NavigationManager _navigationManager;

        public HttpService(HttpClient httpClient,
            ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        public async Task<T> Get<T>(string uri)
        {
            HttpRequestMessage? request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

        public async Task Post(string uri, object value)
        {
            HttpRequestMessage? request = createRequest(HttpMethod.Post, uri, value);
            await sendRequest(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            HttpRequestMessage? request = createRequest(HttpMethod.Post, uri, value);
            return await sendRequest<T>(request);
        }

        public async Task Put(string uri, object value)
        {
            HttpRequestMessage? request = createRequest(HttpMethod.Put, uri, value);
            await sendRequest(request);
        }

        public async Task<T> Put<T>(string uri, object value)
        {
            HttpRequestMessage? request = createRequest(HttpMethod.Put, uri, value);
            return await sendRequest<T>(request);
        }

        public async Task Delete(string uri)
        {
            HttpRequestMessage? request = createRequest(HttpMethod.Delete, uri);
            await sendRequest(request);
        }

        public async Task<T> Delete<T>(string uri)
        {
            HttpRequestMessage? request = createRequest(HttpMethod.Delete, uri);
            return await sendRequest<T>(request);
        }

        private HttpRequestMessage createRequest(HttpMethod method, string uri, object? value = null)
        {
            HttpRequestMessage? request = new HttpRequestMessage(method, uri);
            if (value != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            }

            return request;
        }

        private async Task sendRequest(HttpRequestMessage request)
        {
            await addJwtHeader(request);

            // send request
            using HttpResponseMessage? response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("logout");
                return;
            }

            await handleErrors(response);
        }

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            await addJwtHeader(request);

            //send request
            using HttpResponseMessage? response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("logout");
                return default;
            }

            await handleErrors(response);

            JsonSerializerOptions? options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new StringConverter());
            return await response.Content.ReadFromJsonAsync<T>(options);
        }

        private async Task addJwtHeader(HttpRequestMessage request)
        {
            User? user = await _localStorageService.GetItem<User>("user");
            bool isApiUrl = !request.RequestUri.IsAbsoluteUri;
            if (user != null && isApiUrl)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            }
        }

        private async Task handleErrors(HttpResponseMessage response)
        {
            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                Dictionary<string, string>? error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }
        }
    }
}

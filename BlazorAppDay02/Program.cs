using BlazorAppDay02;
using BlazorAppDay02.Repositories.Categories;
using BlazorAppDay02.Repositories.Products;
using BlazorAppDay02.Repsotories.Accounts;
using BlazorAppDay02.Repsotories.AlertServices;
using BlazorAppDay02.Repsotories.HttpServices;
using BlazorAppDay02.Repsotories.LocalStorageServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .AddScoped<ICategoryRepository, CategoryRepository>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IAccountRepository, AccountRepository>()
    .AddScoped<IAlertService, AlertService>()
    .AddScoped<IHttpService, HttpService>()
    .AddScoped<ILocalStorageService, LocalStorageService>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddHttpClient<ICategoryRepository, CategoryRepository>(
    (sp, optionsHttpClient) =>
         optionsHttpClient.BaseAddress =
         new Uri(sp.GetRequiredService<IConfiguration>()["ProviderWebApiIp"])
    );
builder.Services.AddHttpClient<IProductRepository, ProductRepository>(
    (sp, optionsHttpClient) =>
    optionsHttpClient.BaseAddress =
    new Uri(sp.GetRequiredService<IConfiguration>()["ProviderWebApiIp"])
    );
builder.Services.AddHttpClient<IHttpService, HttpService>(
    (sp, optionsHttpClient) =>
    optionsHttpClient.BaseAddress =
    new Uri(sp.GetRequiredService<IConfiguration>()["ProviderWebApiIp"])
    );

await builder.Build().RunAsync();

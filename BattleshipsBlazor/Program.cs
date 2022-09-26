using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BattleshipsBlazor;
using BattleshipsBlazor.ApiClient;
using MudBlazor.Services;
using RestSharp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient {BaseAddress = new Uri("https://localhost:7151/")};
builder.Services.AddSingleton(sp => new ApiClient(new RestClient(httpClient)));
builder.Services.AddMudServices();

await builder.Build().RunAsync();
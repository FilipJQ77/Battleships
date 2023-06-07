using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Battleships.Blazor;
using Battleships.Core.Entities;
using Battleships.Core.Services;
using Battleships.Core.Services.Interfaces;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var game = new Game();

// Add AI opponent TODO add randomness in the future
game.CreateShips(2, new List<Tile>
{
    new(0,0),
    new(0,1),
    new(0,2),
    new(0,3),
    new(0,4),
    
    new(3,7),
    new(4,7),
    new(5,7),
    new(6,7),
    
    new(9,6),
    new(9,7),
    new(9,8),
    new(9,9),
    
});

builder.Services.AddSingleton<IGame>(_ => game);
builder.Services.AddMudServices();

await builder.Build().RunAsync();
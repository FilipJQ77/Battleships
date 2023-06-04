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

// Add AI opponent
game.CreateShips(2, new List<Tile>
{
    new Tile(0,0),
    new Tile(0,1),
    new Tile(0,2),
    new Tile(0,3),
    new Tile(0,4),
    
    new Tile(3,7),
    new Tile(4,7),
    new Tile(5,7),
    new Tile(6,7),
    
    new Tile(9,6),
    new Tile(9,7),
    new Tile(9,8),
    new Tile(9,9),
    
});

builder.Services.AddSingleton<IGame>(_ => game);
builder.Services.AddMudServices();

await builder.Build().RunAsync();
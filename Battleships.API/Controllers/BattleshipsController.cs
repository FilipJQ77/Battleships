using Battleships.Core.Entities;
using Battleships.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Battleships.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BattleshipsController : ControllerBase
{
    private readonly ILogger<BattleshipsController> _logger;

    private readonly IGame _game;

    public BattleshipsController(ILogger<BattleshipsController> logger, IGame game)
    {
        _logger = logger;
        _game = game;
    }

    [HttpGet("/status")]
    public GameStatus GetStatus()
    {
        var status = _game.GetGameStatus();
        _logger.LogInformation("Status: {Status}", status);
        return status;
    }

    [HttpPost("/ship/add")]
    public IActionResult AddShip(int playerNumber, [FromBody] List<Tile> shipTiles)
    {
        try
        {
            _game.CreateShips(playerNumber, shipTiles);
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "");
            return BadRequest();
        }

        return Ok();
    }

    [HttpPost("/shoot")]
    public bool Shoot(int playerNumber, [FromBody] Tile shot)
    {
        var hit = _game.Shoot(playerNumber, shot);
        _logger.LogInformation("Did shot hit: {Hit}", hit);
        return hit;
    }
}
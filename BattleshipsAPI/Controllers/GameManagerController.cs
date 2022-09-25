using BattleshipsCore.Entities;
using BattleshipsCore.Game.Commands;
using BattleshipsCore.Game.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class GameManagerController : Controller
{
    private readonly IMediator _mediator;

    public GameManagerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/status", Name = "GameStatus")]
    public async Task<ActionResult<GameStatus>> GetGameStatus()
    {
        var request = new GetGameStatusQuery();
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("/ship/available", Name = "GetPossibleShips")]
    public async Task<ActionResult<Dictionary<int, int>>> GetPossibleShips()
    {
        var request = new GetPossibleShipsQuery();
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("/ship/create", Name = "CreateShip")]
    public async Task<ActionResult<bool>> CreateShip([FromQuery] int playerNumber, [FromBody] List<Tile> shipTiles)
    {
        var request = new CreateShipCommand(shipTiles, playerNumber);
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("/shot", Name = "TakeShot")]
    public async Task<ActionResult<bool>> TakeShot([FromQuery] int playerNumber, [FromBody] Tile tile)
    {
        var request = new TakeShotCommand(tile, playerNumber);
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
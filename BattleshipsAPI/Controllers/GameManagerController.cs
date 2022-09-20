using BattleshipsCore.Entities;
using BattleshipsCore.Ships.Commands;
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

    [HttpPost(Name = "CreateShip")]
    public async Task<ActionResult<bool>> CreateShip()
    {
        var request = new CreateShipCommand(new List<Tile>(), 1);
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}
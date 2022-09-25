using BattleshipsCore.Game.Commands;
using BattleshipsCore.Game.Services.Interfaces;
using MediatR;

namespace BattleshipsCore.Game.Handlers;

public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, bool>
{
    private readonly IGameManager _gameManager;

    public CreateShipCommandHandler(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public Task<bool> Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {
        var result = _gameManager.AddShipToBoard(request.Tiles, request.PlayerNumber);
        return Task.FromResult(result);
    }
}
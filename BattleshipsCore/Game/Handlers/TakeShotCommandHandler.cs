using BattleshipsCore.Game.Commands;
using BattleshipsCore.Game.Services.Interfaces;
using MediatR;

namespace BattleshipsCore.Game.Handlers;

public class TakeShotCommandHandler : IRequestHandler<TakeShotCommand, bool>
{
    private readonly IGameManager _gameManager;

    public TakeShotCommandHandler(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public Task<bool> Handle(TakeShotCommand request, CancellationToken cancellationToken)
        => Task.FromResult(_gameManager.TakeShot(request.Tile, request.PlayerNumber));
}
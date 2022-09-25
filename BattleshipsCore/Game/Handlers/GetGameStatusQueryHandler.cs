using BattleshipsCore.Entities;
using BattleshipsCore.Game.Queries;
using BattleshipsCore.Game.Services.Interfaces;
using MediatR;

namespace BattleshipsCore.Game.Handlers;

public class GetGameStatusQueryHandler : IRequestHandler<GetGameStatusQuery, GameStatus>
{
    private readonly IGameManager _gameManager;

    public GetGameStatusQueryHandler(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public Task<GameStatus> Handle(GetGameStatusQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_gameManager.GetGameStatus());
}
using BattleshipsCore.Game.Queries;
using BattleshipsCore.Game.Services.Interfaces;
using MediatR;

namespace BattleshipsCore.Game.Handlers;

public class GetPossibleShipsQueryHandler : IRequestHandler<GetPossibleShipsQuery, Dictionary<int, int>>
{
    private readonly IGameManager _gameManager;

    public GetPossibleShipsQueryHandler(IGameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public Task<Dictionary<int, int>> Handle(GetPossibleShipsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_gameManager.GetPossibleShips());
    }
}
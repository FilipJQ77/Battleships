using MediatR;

namespace BattleshipsCore.Game.Queries;

public record GetPossibleShipsQuery : IRequest<Dictionary<int, int>>;
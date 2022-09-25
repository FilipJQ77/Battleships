using BattleshipsCore.Entities;
using MediatR;

namespace BattleshipsCore.Game.Queries;

public record GetGameStatusQuery : IRequest<GameStatus>;
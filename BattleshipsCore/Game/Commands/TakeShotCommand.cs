using BattleshipsCore.Entities;
using MediatR;

namespace BattleshipsCore.Game.Commands;

public record TakeShotCommand(Tile Tile, int PlayerNumber) : IRequest<bool>;
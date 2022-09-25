using BattleshipsCore.Entities;
using MediatR;

namespace BattleshipsCore.Game.Commands;

public record CreateShipCommand(IList<Tile> Tiles, int PlayerNumber) : IRequest<bool>;
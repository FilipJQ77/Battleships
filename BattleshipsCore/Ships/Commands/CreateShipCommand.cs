using BattleshipsCore.Entities;
using MediatR;

namespace BattleshipsCore.Ships.Commands;

public record CreateShipCommand(IEnumerable<Tile> Tiles, int PlayerNumber) : IRequest<bool>;
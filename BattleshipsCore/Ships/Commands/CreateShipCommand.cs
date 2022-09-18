using BattleshipsCore.Entities;
using MediatR;

namespace BattleshipsCore.Ships.Commands;

public record CreateShipCommand(IEnumerable<Tile> Tiles) : IRequest<bool>
{
    public IEnumerable<Tile> Tiles { get; set; } = Tiles;
}
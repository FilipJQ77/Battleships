namespace BattleshipsCore.Entities;

public class Ship
{
    public Ship(List<ShipPart> shipParts)
    {
        ShipParts = shipParts;
    }

    internal List<ShipPart> ShipParts { get; }

    public ShipPart? CheckShot(Tile shotTile)
        => ShipParts.FirstOrDefault(a => a.Tile.X == shotTile.X && a.Tile.Y == shotTile.Y);
}
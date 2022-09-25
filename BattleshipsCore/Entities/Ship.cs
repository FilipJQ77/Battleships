namespace BattleshipsCore.Entities;

public class Ship
{
    public Ship(IList<ShipPart> shipParts)
    {
        ShipParts = shipParts;
    }

    internal IList<ShipPart> ShipParts { get; }

    public ShipPart? CheckShot(Tile shotTile)
        => ShipParts.FirstOrDefault(a => a.Tile.X == shotTile.X && a.Tile.Y == shotTile.Y);
}
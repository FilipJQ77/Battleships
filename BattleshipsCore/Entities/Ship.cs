namespace BattleshipsCore.Entities;

public class Ship
{
    public Ship(IEnumerable<ShipPart> shipParts)
    {
        ShipParts = shipParts;
    }

    internal IEnumerable<ShipPart> ShipParts { get; }

    public bool CheckShotAgainstShip(Shot shot)
    {
        return ShipParts.FirstOrDefault(a => a.Tile.X == shot.Tile.X && a.Tile.Y == shot.Tile.Y) != null;
    }
}
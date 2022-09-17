namespace BattleshipsCore.Entities;

public class Ship
{
    public Ship(IEnumerable<ShipPart> shipParts)
    {
        ShipParts = shipParts;
    }

    private IEnumerable<ShipPart> ShipParts { get; }
}
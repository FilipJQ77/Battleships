namespace BattleshipsCore.Entities;

public class ShipPart
{
    public ShipPart(Tile tile, bool destroyed)
    {
        Tile = tile;
        Destroyed = destroyed;
    }

    private Tile Tile { get; }

    private bool Destroyed { get; }
}
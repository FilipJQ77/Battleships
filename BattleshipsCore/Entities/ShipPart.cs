namespace BattleshipsCore.Entities;

public class ShipPart
{
    public ShipPart(Tile tile, bool destroyed)
    {
        Tile = tile;
        Destroyed = destroyed;
    }

    internal Tile Tile { get; }

    internal bool Destroyed { get; set; }
}
namespace BattleshipsCore.Entities;

public class Shot
{
    public Shot(Tile tile, bool shotShip)
    {
        Tile = tile;
        ShotShip = shotShip;
    }

    internal Tile Tile { get; }

    internal bool ShotShip { get; }
}
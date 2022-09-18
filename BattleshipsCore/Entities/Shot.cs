namespace BattleshipsCore.Entities;

public class Shot
{
    public Shot(Tile tile, bool shotBefore)
    {
        Tile = tile;
        ShotBefore = shotBefore;
    }

    internal Tile Tile { get; }

    internal bool ShotBefore { get; }
}
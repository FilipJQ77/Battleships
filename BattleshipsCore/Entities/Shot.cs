namespace BattleshipsCore.Entities;

public class Shot
{
    public Shot(Tile tile, bool shotBefore)
    {
        Tile = tile;
        ShotBefore = shotBefore;
    }

    private Tile Tile { get; }

    private bool ShotBefore { get; }
}
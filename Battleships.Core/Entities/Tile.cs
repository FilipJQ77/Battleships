namespace Battleships.Core.Entities;

public record Tile(int X, int Y)
{
    public virtual bool Equals(Tile? other) => X == other?.X && Y == other?.Y;

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString() => $"[{X}, {Y}]";
}
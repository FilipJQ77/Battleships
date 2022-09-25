namespace BattleshipsCore.Entities;

public record Tile(int X, int Y)
{
    public virtual bool Equals(Tile? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
        => HashCode.Combine(X, Y);


    public bool CheckForCollision(Tile other)
        => (X == other.X && Math.Abs(other.Y - Y) <= 1) || (Y == other.Y && Math.Abs(X - other.X) <= 1);


    public bool CheckForCollision(IEnumerable<Tile> tiles)
        => tiles.Any(s => s.Equals(this) || CheckForCollision(s));

    public bool CheckInBounds(int gridSize)
        => 0 <= X && X < gridSize && 0 <= Y && Y < gridSize;
}
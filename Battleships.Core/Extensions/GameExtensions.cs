using Battleships.Core.Entities;

namespace Battleships.Core.Extensions;

public static class GameExtensions
{
    public static bool WouldBeOutOfBounds(this Tile tile, int boardSize) =>
        tile.X < 0 || tile.X >= boardSize || tile.Y < 0 || tile.Y >= boardSize;

    public static List<List<Tile>> GroupAdjacentTiles(this List<Tile> tiles)
    {
        var tileGroups = new List<List<Tile>>();
        var visitedTiles = new HashSet<Tile>();

        foreach (var tile in tiles)
        {
            if (visitedTiles.Contains(tile))
                continue;

            var group = tile.BreadthFirstSearch(tiles);
            tileGroups.Add(group);

            foreach (var visitedTile in group)
            {
                visitedTiles.Add(visitedTile);
            }
        }

        return tileGroups;
    }

    public static List<Tile> BreadthFirstSearch(this Tile startTile, List<Tile> tiles)
    {
        var queue = new Queue<Tile>();
        var group = new List<Tile>();

        queue.Enqueue(startTile);
        group.Add(startTile);

        while (queue.Count > 0)
        {
            var currentTile = queue.Dequeue();

            // Find adjacent tiles
            var adjacentTiles = tiles.Where(t => t.IsAdjacent(currentTile)).ToList();

            foreach (var adjacentTile in adjacentTiles)
            {
                if (group.Contains(adjacentTile)) continue;
                queue.Enqueue(adjacentTile);
                group.Add(adjacentTile);
            }
        }

        return group;
    }

    public static bool IsAdjacent(this Tile tile, Tile otherTile)
    {
        return (tile.X == otherTile.X && Math.Abs(tile.Y - otherTile.Y) == 1) ||
               (tile.Y == otherTile.Y && Math.Abs(tile.X - otherTile.X) == 1);
    }
}
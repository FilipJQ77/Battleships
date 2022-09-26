using System.Text;

namespace BattleshipsCore.Entities;

public record GameStatus(List<List<Ship>> PlayerShips, List<List<Shot>> PlayerShots)
{
    public override string ToString()
    {
        var stringBuilder = new StringBuilder("Player 1 ships: \n");
        PlayerShips[0].ForEach(ship =>
            ship.ShipParts.ForEach(part => stringBuilder.Append($"X: {part.Tile.X}, Y: {part.Tile.Y}\n")));

        stringBuilder.Append("Player 2 ships: \n");
        PlayerShips[1].ForEach(ship =>
            ship.ShipParts.ForEach(part => stringBuilder.Append($"X: {part.Tile.X}, Y: {part.Tile.Y}\n")));

        stringBuilder.Append("Player 1 shots: \n");
        PlayerShots[0].ForEach(shot => stringBuilder.Append($"X: {shot.Tile.X}, Y: {shot.Tile.Y}\n"));

        stringBuilder.Append("Player 2 shots: \n");
        PlayerShots[1].ForEach(shot => stringBuilder.Append($"X: {shot.Tile.X}, Y: {shot.Tile.Y}\n"));

        return stringBuilder.ToString();
    }
};
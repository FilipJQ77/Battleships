using BattleshipsCore.Entities;
using BattleshipsCore.Game.Services.Interfaces;

namespace BattleshipsCore.Game.Services;

public class GameManager : IGameManager
{
    /// <summary>
    /// This dictionary contains information about sizes of ships that are available in game and their quantity.
    /// For example, the game can contain:
    /// 1 ship of size 5,
    /// 1 ship of size 4,
    /// 2 ships of size 3,
    /// 1 ship of size 2.
    /// </summary>
    private Dictionary<int, int> _availableShips = new()
    {
        {5, 1},
        {4, 1},
        {3, 2},
        {2, 1}
    };

    private int _gridSize = 10;

    private readonly List<List<Ship>> _playerShips = new()
    {
        new(),
        new(),
    };

    private readonly List<List<Shot>> _playerShots = new()
    {
        new(),
        new()
    };

    public GameStatus GetGameStatus() => new(_playerShips, _playerShots);

    public Dictionary<int, int> GetPossibleShips()
    {
        return _availableShips;
    }

    public bool AddShipToBoard(IList<Tile> tiles, int playerNumber)
    {
        if (!tiles.Any())
        {
            return false;
        }

        // The given ship length is not available.
        if (!_availableShips.ContainsKey(tiles.Count))
        {
            return false;
        }

        // The player cannot put a second ship with 5 tiles, if only one 5 tile ship is available.
        var playerShipCount = _playerShips[playerNumber].Count(x => x.ShipParts.Count() == tiles.Count);
        if (playerShipCount >= _availableShips[tiles.Count])
        {
            return false;
        }

        // For the ship to be correct, all tiles need to be in a row or a column.
        var (exampleX, exampleY) = (tiles.First().X, tiles.First().Y);
        if (!tiles.All(t => t.X == exampleX || t.Y == exampleY))
        {
            return false;
        }

        // The ship cannot be outside the board.
        if (!tiles.All(t => t.CheckInBounds(_gridSize)))
        {
            return false;
        }

        // The new ship cannot collide with previous ships.
        if (_playerShips[playerNumber].Any(s => s.ShipParts.Any(p => p.Tile.CheckForCollision(tiles))))
        {
            return false;
        }

        var newShip = new Ship(tiles.Select(t => new ShipPart(t, false)).ToList());
        _playerShips[playerNumber].Add(newShip);
        return true;
    }

    public bool TakeShot(Tile shotTile, int playerNumber)
    {
        if (!shotTile.CheckInBounds(_gridSize))
        {
            return false;
        }

        if (_playerShots[playerNumber].Any(s => s.Tile.Equals(shotTile)))
        {
            return false;
        }

        var enemyPlayerNumber = playerNumber == 0 ? 1 : 0;
        ShipPart? shotShipPart = null;
        foreach (var ship in _playerShips[enemyPlayerNumber])
        {
            shotShipPart = ship.CheckShot(shotTile);
            if (shotShipPart is not null)
            {
                break;
            }
        }

        if (shotShipPart is null) return false;
        
        shotShipPart.Destroyed = true;
        return true;

    }
}
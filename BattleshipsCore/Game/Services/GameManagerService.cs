using BattleshipsCore.Entities;
using BattleshipsCore.Game.Services.Interfaces;

namespace BattleshipsCore.Game.Services;

public class GameManagerService : IGameManager
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

    private IEnumerable<Ship> _player1Ships;

    private IEnumerable<Ship> _player2Ships;

    private IEnumerable<Shot> _player1Shots;

    private IEnumerable<Shot> _player2Shots;

    public bool AddShipToBoard(IEnumerable<Tile> tiles, int playerNumber)
    {
        var random = new Random();
        // TODO for testing purposes only
        return random.NextDouble() < 0.5;
    }

    public bool TakeShot(Shot shot, int playerNumber)
    {
        throw new NotImplementedException();
    }
}
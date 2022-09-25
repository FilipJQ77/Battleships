using BattleshipsCore.Entities;

namespace BattleshipsCore.Game.Services.Interfaces;

public interface IGameManager
{
    GameStatus GetGameStatus();
    
    Dictionary<int, int> GetPossibleShips();

    bool AddShipToBoard(IList<Tile> tiles, int playerNumber);

    bool TakeShot(Tile shotTile, int playerNumber);
}
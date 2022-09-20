using BattleshipsCore.Entities;

namespace BattleshipsCore.Game.Services.Interfaces;

public interface IGameManager
{
    bool AddShipToBoard(IEnumerable<Tile> tiles, int playerNumber);

    bool TakeShot(Shot shot, int playerNumber);
}
using BattleshipsCore.Entities;

namespace BattleshipsCore.Game.Services.Interfaces;

public interface IGameManager
{
    bool AddShipToBoard(IEnumerable<Tile> tiles);

    bool TakeShot(Shot shot);
}
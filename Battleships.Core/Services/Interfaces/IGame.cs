using Battleships.Core.Entities;

namespace Battleships.Core.Services.Interfaces;

public interface IGame
{
    public int BoardSize { get; init; }
    Dictionary<int, int> PossibleShips { get; init; }
    public Player Player1 { get; init; }
    public Player Player2 { get; init; }
    GameStatus GetGameStatus();
    void CreateShips(int playerNumber);
    void CreateShips(int playerNumber, List<Tile> shipTiles);
    bool Shoot(int playerNumber, Tile shotTile);
}
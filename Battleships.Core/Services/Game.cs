using Battleships.Core.Entities;
using Battleships.Core.Exceptions;
using Battleships.Core.Services.Interfaces;

namespace Battleships.Core.Services;

public class Game : IGame
{
    public int BoardSize { get; init; }
    public Dictionary<int, int> PossibleShips { get; init; }
    public Player Player1 { get; init; }
    public Player Player2 { get; init; }

    public Game(int? boardSize = null, Dictionary<int, int>? possibleShips = null)
    {
        BoardSize = boardSize ?? 10;
        PossibleShips = possibleShips ?? new Dictionary<int, int>
        {
            {5, 1},
            {4, 2}
        };
        Player1 = Player.CreatePlayer(BoardSize);
        Player2 = Player.CreatePlayer(BoardSize);
    }

    public ShipTileState[,] ShipTileStates(int playerNumber)
    {
        return playerNumber switch
        {
            1 => Player1.PlayerGameBoard.ShipTilesStates,
            2 => Player2.PlayerGameBoard.ShipTilesStates,
            _ => throw new IncorrectPlayerException("Incorrect player number")
        };
    }

    public GameStatus GetGameStatus()
    {
        var status = new GameStatus(Player1, Player2);
        return status;
    }

    public void ToggleCreatingShip(int playerNumber, int x, int y)
    {
        switch (playerNumber)
        {
            case 1:
                Player1.PlayerGameBoard.ToggleCreatingShip(x, y);
                break;
            case 2:
                Player2.PlayerGameBoard.ToggleCreatingShip(x, y);
                break;
            default:
                throw new IncorrectPlayerException("Incorrect player number");
        }
    }

    public void CreateShips(int playerNumber)
    {
        switch (playerNumber)
        {
            case 1:
                Player1.PlayerGameBoard.PlaceShips(PossibleShips);
                break;
            case 2:
                Player2.PlayerGameBoard.PlaceShips(PossibleShips);
                break;
            default:
                throw new IncorrectPlayerException("Incorrect player number");
        }
    }

    public void CreateShips(int playerNumber, List<Tile> shipTiles)
    {
        switch (playerNumber)
        {
            case 1:
                Player1.PlayerGameBoard.PlaceShips(shipTiles, PossibleShips);
                break;
            case 2:
                Player2.PlayerGameBoard.PlaceShips(shipTiles, PossibleShips);
                break;
            default:
                throw new IncorrectPlayerException("Incorrect player number");
        }
    }

    public bool Shoot(int playerNumber, Tile shotTile)
    {
        return playerNumber switch
        {
            1 => Player1.PlayerGameBoard.ShootTile(shotTile, Player2.PlayerGameBoard),
            2 => Player2.PlayerGameBoard.ShootTile(shotTile, Player1.PlayerGameBoard),
            _ => throw new IncorrectPlayerException("Incorrect player number")
        };
    }
}
namespace Battleships.Core.Entities;

public record Player(GameBoard PlayerGameBoard)
{
    public bool Lost => PlayerGameBoard.Lost;
    public static Player CreatePlayer(int boardSize) => new(new GameBoard(boardSize));
}
// See https://aka.ms/new-console-template for more information

using Battleships.Core.Entities;
using Battleships.Core.Services;

const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

var boardSize = 10;

var game = new Game(boardSize: boardSize);

for (var i = 0; i < boardSize; i++)
{
    for (var j = 0; j < boardSize; j++)
    {
        var shipState = game.Player1.PlayerGameBoard.ShipTiles[i, j];
        var str = shipState switch
        {
            ShipTileState.Empty => $"{alphabet[i]}{j + 1} ",
            ShipTileState.OtherPlayerMiss => "MS ",
            ShipTileState.Ship => "SS ",
            ShipTileState.DestroyedShip => "XX ",
        };

        Console.Write(str);
    }

    Console.WriteLine();
}
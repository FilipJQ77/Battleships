using Battleships.Core.Exceptions;
using Battleships.Core.Extensions;

namespace Battleships.Core.Entities;

public enum ShipTileState
{
    Empty,
    CreatingShip,
    Ship,
    DestroyedShip,
    OtherPlayerMiss,
}

public enum ShotTileState
{
    Empty,
    Shooting,
    Miss,
    Hit
}

public class GameBoard
{
    public int BoardSize { get; }
    public List<Tile> PlayerShipTiles { get; private set; }
    public ShipTileState[,] ShipTilesStates { get; }
    public ShotTileState[,] ShotTilesStates { get; }

    public bool Ready { get; private set; }

    public (int x, int y) CurrentShootingTile { get; set; }

    public bool Lost => PlayerShipTiles.Select(tile => ShipTilesStates[tile.X, tile.Y])
        .All(state => state == ShipTileState.DestroyedShip);

    public GameBoard(int boardSize)
    {
        BoardSize = boardSize;
        Ready = false;
        CurrentShootingTile = (0, 0);
        PlayerShipTiles = new List<Tile>();
        ShipTilesStates = new ShipTileState[boardSize, boardSize];
        ShotTilesStates = new ShotTileState[boardSize, boardSize];
        for (var i = 0; i < BoardSize; i++)
        {
            for (var j = 0; j < BoardSize; j++)
            {
                ShipTilesStates[i, j] = ShipTileState.Empty;
                ShotTilesStates[i, j] = ShotTileState.Empty;
            }
        }
    }

    public void ToggleCreatingShip(int x, int y)
    {
        if (Ready)
        {
            throw new ShipValidationException("Creating ship here is prohibited.");
        }

        ShipTilesStates[x, y] = ShipTilesStates[x, y] switch
        {
            ShipTileState.Empty => ShipTileState.CreatingShip,
            ShipTileState.CreatingShip => ShipTileState.Empty,
            _ => throw new ShipValidationException("Creating ship here is prohibited.")
        };
    }

    public void PlaceShips(Dictionary<int, int> possibleShips)
    {
        var shipTiles = new List<Tile>();
        for (var i = 0; i < BoardSize; i++)
        {
            for (var j = 0; j < BoardSize; j++)
            {
                if (ShipTilesStates[i, j] == ShipTileState.CreatingShip)
                {
                    shipTiles.Add(new Tile(i, j));
                }
            }
        }

        PlaceShips(shipTiles, possibleShips);
    }

    public void PlaceShips(List<Tile> shipsTiles, Dictionary<int, int> possibleShips)
    {
        if (!shipsTiles.Any())
        {
            throw new ArgumentException("There are no ships to place.");
        }

        if (shipsTiles.Any(x => x.WouldBeOutOfBounds(BoardSize)))
        {
            throw new OutOfBoundsException("Ship tiles would be out of bounds.");
        }

        var ships = shipsTiles.GroupAdjacentTiles();

        var shipSizes = new Dictionary<int, int>();

        foreach (var shipSize in ships.Select(x => x.Count))
        {
            if (shipSizes.ContainsKey(shipSize))
            {
                shipSizes[shipSize]++;
            }
            else
            {
                shipSizes.Add(shipSize, 1);
            }
        }

        if (shipSizes.Any(ship => !possibleShips.ContainsKey(ship.Key) || possibleShips[ship.Key] != ship.Value))
        {
            throw new ShipValidationException(
                "Incorrect ship sizes (if the ships touch each other they are then counted as one ship.)");
        }

        if (ships.Any(ship =>
                ship.Any(tile => tile.X != ship.First().X) &&
                ship.Any(tile => tile.Y != ship.First().Y)))
        {
            throw new ShipValidationException("Ship tiles must be vertical or horizontal.");
        }

        foreach (var shipTile in shipsTiles)
        {
            ShipTilesStates[shipTile.X, shipTile.Y] = ShipTileState.Ship;
        }

        Ready = true;
        PlayerShipTiles = new List<Tile>(shipsTiles);
    }

    public bool ShootTile(Tile shotTile, GameBoard otherPlayerBoard)
    {
        if (!Ready)
        {
            throw new IncorrectPlayerException("You need to put ships first in order to shoot.");
        }

        if (shotTile.WouldBeOutOfBounds(BoardSize))
        {
            throw new OutOfBoundsException("Given shot tile would be out of bounds.");
        }

        if (otherPlayerBoard.ShipTilesStates[shotTile.X, shotTile.Y] == ShipTileState.Ship ||
            otherPlayerBoard.ShipTilesStates[shotTile.X, shotTile.Y] == ShipTileState.DestroyedShip)
        {
            ShotTilesStates[shotTile.X, shotTile.Y] = ShotTileState.Hit;
            otherPlayerBoard.ShipTilesStates[shotTile.X, shotTile.Y] = ShipTileState.DestroyedShip;
            return true;
        }
        else
        {
            ShotTilesStates[shotTile.X, shotTile.Y] = ShotTileState.Miss;
            otherPlayerBoard.ShipTilesStates[shotTile.X, shotTile.Y] = ShipTileState.OtherPlayerMiss;
            return false;
        }
    }
}
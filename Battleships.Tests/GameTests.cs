using Battleships.Core.Entities;
using Battleships.Core.Exceptions;
using Battleships.Core.Services;
using Battleships.Core.Services.Interfaces;

namespace Battleships.Tests;

public class GameTests
{
    private IGame _game;

    [SetUp]
    public void xd()
    {
        var possibleShips = new Dictionary<int, int>
        {
            {2, 1} // 1 ship of size 2
        };
        _game = new Game(10, possibleShips);
    }

    [Test]
    public void TestCreateCorrectShips()
    {
        Assert.DoesNotThrow(() => _game.CreateShips(1, new List<Tile>
        {
            new Tile(0, 0),
            new Tile(0, 1),
        }));

        Assert.DoesNotThrow(() =>
            _game.CreateShips(2, new List<Tile>
            {
                new Tile(0, 0),
                new Tile(0, 1),
            }));
    }

    [Test]
    public void TestCreateIncorrectShips()
    {
        Assert.Throws<IncorrectPlayerException>(() =>
            _game.CreateShips(3, new List<Tile>
            {
                new(0, 0),
                new(0, 1),
            }));

        Assert.Throws<ArgumentException>(() =>
            _game.CreateShips(1, new List<Tile>()));

        Assert.Throws<OutOfBoundsException>(() => _game.CreateShips(1, new List<Tile>
        {
            new(-1, 0),
            new(0, 1),
        }));

        Assert.Throws<ShipValidationException>(() => _game.CreateShips(1, new List<Tile>
        {
            new(0, 0),
            new(0, 1),
            new(0, 2),
        }));

        Assert.Throws<ShipValidationException>(() => _game.CreateShips(1, new List<Tile>
        {
            new(0, 0),
            new(1, 1),
        }));
    }

    [Test]
    public void TestShootCorrectly()
    {
        _game.CreateShips(1, new List<Tile>
        {
            new(0, 0),
            new(0, 1),
        });

        _game.CreateShips(2, new List<Tile>
        {
            new(1, 1),
            new(1, 2),
        });

        var result = _game.Shoot(1, new Tile(1, 1));
        Assert.That(result, Is.True);

        var result2 = _game.Shoot(2, new Tile(0, 0));
        Assert.That(result2, Is.True);

        var result3 = _game.Shoot(1, new Tile(3, 3));
        Assert.That(result3, Is.False);
    }

    [Test]
    public void TestShootIncorrectly()
    {
        _game.CreateShips(1, new List<Tile>
        {
            new(0, 0),
            new(0, 1),
        });

        Assert.Throws<IncorrectPlayerException>(() => _game.Shoot(1, new Tile(1, 1)));

        _game.CreateShips(2, new List<Tile>
        {
            new(1, 1),
            new(1, 2),
        });

        Assert.Throws<OutOfBoundsException>(() => _game.Shoot(1, new Tile(-1, 0)));
    }

    [Test]
    public void TestGameOver()
    {
        _game.CreateShips(1, new List<Tile>
        {
            new(0, 0),
            new(0, 1),
        });

        _game.CreateShips(2, new List<Tile>
        {
            new(1, 1),
            new(1, 2),
        });

        _game.Shoot(1, new Tile(1, 1));
        _game.Shoot(2, new Tile(0, 0));
        _game.Shoot(1, new Tile(1, 2));
        Assert.That(_game.Player2.Lost, Is.True);
    }
}
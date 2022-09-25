namespace BattleshipsCore.Entities;

public record GameStatus(List<List<Ship>> PlayerShips, List<List<Shot>> PlayerShots);
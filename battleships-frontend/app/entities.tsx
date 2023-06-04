export interface GameStatus {
  player1: Player;
  player2: Player;
}

interface Player {
  ships: Array<Ship>;
  shots: Array<Shot>;
}

interface Ship {
  shipParts: Array<ShipPart>;
}

interface ShipPart {
  tile: Tile;
  destroyed: boolean;
}

interface Shot {
  tile: Tile;
}

interface Tile {
  x: number;
  y: number;
}

export const alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
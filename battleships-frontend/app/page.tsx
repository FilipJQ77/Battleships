"use client";

import { useState } from "react";
import { fetchRoute } from "./fetch";
import {
  Box,
  Button,
  GridItem,
  HStack,
  SimpleGrid,
  Text,
} from "@chakra-ui/react";
import { alphabet, GameStatus } from "./entities";

export default function Home() {
  const gridSize = 10;

  const preparedGrid = [];

  for (let y = 0; y < gridSize; y++) {
    for (let x = 0; x < gridSize; x++) {
      preparedGrid.push({
        x,
        y,
        isShip: false,
      });
    }
  }

  const [grid, setGrid] = useState(preparedGrid);
  const [gameStatus, setGameStatus] = useState<GameStatus | null>(null);

  const getGameStatus = async () => {
    const result = (await fetchRoute("status")) as GameStatus;
    setGameStatus(result);
    setNewGrid(result);
  };

  const setNewGrid = (status: GameStatus | null) => {
    if (!status) return;

    const newGrid = grid.map((item) => ({ ...item, isShip: false }));

    status.player1.ships.forEach((ship) => {
      ship.shipParts.forEach((part) => {
        const { x, y } = part.tile;
        const index = y * gridSize + x;
        newGrid[index] = {
          ...newGrid[index],
          isShip: true,
        };
      });
    });

    setGrid(newGrid);
  };

  return (
    <HStack>
      <Box m={5} display="inline-block">
        <Text mb={2}>Player ships</Text>
        <SimpleGrid columns={gridSize} spacing={1}>
          {grid.map(({ x, y, isShip }) => (
            <GridItem
              key={`${x}-${y}`}
              bg={isShip ? "blue.500" : "gray.200"}
              p={2}
              textAlign="center"
              width="3em"
              height="3em"
            >
              <Text color={isShip ? "white" : undefined}>
                {`${alphabet[x]}${y + 1}`}
              </Text>
            </GridItem>
          ))}
        </SimpleGrid>
        <Button onClick={getGameStatus}>Place ship</Button>
      </Box>
      <Box m={5} display="inline-block">
        <Text mb={2}>Player shots</Text>
        <SimpleGrid columns={gridSize} spacing={1}>
          {grid.map(({ x, y, isShip }) => (
            <GridItem
              key={`${x}-${y}`}
              bg={isShip ? "blue.500" : "gray.200"}
              p={2}
              textAlign="center"
              width="3em"
              height="3em"
            >
              <Text color={isShip ? "white" : undefined}>
                {`${alphabet[x]}${y + 1}`}
              </Text>
            </GridItem>
          ))}
        </SimpleGrid>
        <Button>Shoot</Button>
      </Box>
    </HStack>
  );
}

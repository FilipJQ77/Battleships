import { GridItem, Text } from "@chakra-ui/react";
import { useState } from "react";
import { alphabet } from "@/app/entities";

export default function ShipGridItem(x: number, y: number) {
  const [text, setText] = useState("");
  const [isShip, setIsShip] = useState("");

  return (
    <GridItem
      key={`${x}-${y}`}
      bg="gray.200"
      p={2}
      textAlign="center"
      width="3em"
      height="3em"
    >
      <Text>{`${alphabet[x]}${y + 1}`}</Text>
    </GridItem>
  );
}

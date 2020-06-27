using System;

namespace EscapeGame {

    class GameController {
        public Map Map { get; set; }

        public GameController() {
            Map = new Map(1);
        }

        public bool Launch() {
            ConsoleKey key;
            int radius = 13;
            int playerPosX = 3, playerPosY = 3, newPlayerPosX, newPlayerPosY;
            Map.RenderMap(playerPosX, playerPosY, radius);
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Escape)) {
                newPlayerPosX = playerPosX;
                newPlayerPosY = playerPosY;
                switch(key) {
                    
                    case ConsoleKey.LeftArrow:
                        if(Map.isFreeChunk(playerPosX - 1, playerPosY)) {
                            newPlayerPosX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Map.isFreeChunk(playerPosX + 1, playerPosY)) {
                            newPlayerPosX++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Map.isFreeChunk(playerPosX, playerPosY - 1)) {
                            newPlayerPosY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Map.isFreeChunk(playerPosX, playerPosY + 1)) {
                            newPlayerPosY++;
                        }
                        break;
                }

                if(newPlayerPosX != playerPosX || newPlayerPosY != playerPosY) {
                    playerPosX = newPlayerPosX;
                    playerPosY = newPlayerPosY;
                    Map.RenderMap(playerPosX, playerPosY, radius);
                }
            }
            return false;
        }

    }
}
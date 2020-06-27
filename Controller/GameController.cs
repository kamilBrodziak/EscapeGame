using System;

namespace EscapeGame {

    class GameController {
        public Map Map { get; set; }
        public Player Player { get; set; }

        public GameController() {
            Map = new Map(1);
        }

        public bool Launch() {
            ConsoleKey key;
            Player = new Player();
            int radius = 13;
            int newPlayerPosX, newPlayerPosY;
            Map.RenderMap(playerPosX, playerPosY, radius);
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Escape)) {
                newPlayerPosX = Player.PosX;
                newPlayerPosY = Player.PosY;
                switch(key) {
                    case ConsoleKey.LeftArrow:
                        if(Map.isFreeChunk(Player.PosX - 1, Player.PosY)) {
                            newPlayerPosX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (Map.isFreeChunk(Player.PosX + 1, Player.PosY)) {
                            newPlayerPosX++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Map.isFreeChunk(Player.PosX, Player.PosY - 1)) {
                            newPlayerPosY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Map.isFreeChunk(Player.PosX, Player.PosY + 1)) {
                            newPlayerPosY++;
                        }
                        break;
                }

                if(newPlayerPosX != Player.PosX || newPlayerPosY != Player.PosY) {
                    Player.PosX = newPlayerPosX;
                    Player.PosY = newPlayerPosY;
                    Map.RenderMap(Player.PosX, Player.PosY, radius);
                }
            }
            return false;
        }

    }
}
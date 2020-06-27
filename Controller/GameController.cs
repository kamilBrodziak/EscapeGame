using EscapeGame.Controller;
using System;
using System.Collections.Generic;

namespace EscapeGame {

    class GameController {
        public MapController MapController { get; set; }
        public PlayerController PlayerController { get; set; }
        private ItemsController itemsController;

        public GameController() {
            MapController = new MapController();
            itemsController = new ItemsController();
            PlayerController = new PlayerController();
        }

        public bool Launch() {
            ConsoleKey key;
            int newPlayerPosX, newPlayerPosY, playerPosX, playerPosY;
            MapController.RenderMap(PlayerController.Player);
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Escape)) {
                playerPosX = PlayerController.Player.PosX;
                playerPosY = PlayerController.Player.PosY;
                newPlayerPosX = playerPosX;
                newPlayerPosY = playerPosY;
                switch(key) {
                    case ConsoleKey.LeftArrow:
                        if(MapController.isFreeChunk(playerPosX - 1, playerPosY)) {
                            newPlayerPosX--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (MapController.isFreeChunk(playerPosX + 1, playerPosY)) {
                            newPlayerPosX++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (MapController.isFreeChunk(playerPosX, playerPosY - 1)) {
                            newPlayerPosY--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (MapController.isFreeChunk(playerPosX, playerPosY + 1)) {
                            newPlayerPosY++;
                        }
                        break;
                }

                bool playerMoved = PlayerController.MakeMove(newPlayerPosX, newPlayerPosY);
                if(playerMoved) {
                    MapController.RenderMap(PlayerController.Player);
                }
            }
            return false;
        }

    }
}
using EscapeGame.Controller;
using System;
using System.Collections.Generic;

namespace EscapeGame {

    class GameController {
        private MapController mapController;
        private PlayerController playerController;
        private ItemsController itemsController;
        private InventoryController inventoryController;

        public GameController() {
            mapController = new MapController();
            itemsController = new ItemsController();
            playerController = new PlayerController();
            inventoryController = new InventoryController(playerController.Player.Inventory);
        }

        public bool Launch() {
            ConsoleKey key;
            int playerPosX, playerPosY, newPlayerPosX, newPlayerPosY;
            mapController.RenderMap(playerController.Player);
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Escape)) {
                playerPosX = playerController.Player.PosX;
                playerPosY = playerController.Player.PosY;
                newPlayerPosX = playerPosX;
                newPlayerPosY = playerPosY;
                bool renderMap = true;

                switch(key) {
                    case ConsoleKey.LeftArrow:
                        newPlayerPosX--;
                        break;
                    case ConsoleKey.RightArrow:
                        newPlayerPosX++;
                        break;
                    case ConsoleKey.UpArrow:
                        newPlayerPosY--;
                        break;
                    case ConsoleKey.DownArrow:
                        newPlayerPosY++;
                        break;
                    case ConsoleKey.I:
                        inventoryController.OpenInventory();
                        break;
                    default:
                        renderMap = false;
                        break;
                }
                
                if(newPlayerPosX != playerPosX || newPlayerPosY != playerPosY) {
                    if(mapController.IsFreeChunk(newPlayerPosX, newPlayerPosY)) {
                        playerController.MakeMove(newPlayerPosX, newPlayerPosY);
                    } else if(mapController.IsItemBoxChunk(newPlayerPosX, newPlayerPosY)) {
                        playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                        playerController.MakeMove(newPlayerPosX, newPlayerPosY);
                        mapController.SetChunk(newPlayerPosX, newPlayerPosY, ChunkType.Floor);
                    } else {
                        renderMap = false;
                    }
                }
                if(renderMap) {
                    mapController.RenderMap(playerController.Player);
                }
            }
            return false;
        }

    }
}
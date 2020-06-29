using EscapeGame.Controller;
using EscapeGame.View;
using System;

namespace EscapeGame {

    class GameController {
        private MapController mapController;
        private PlayerController playerController;
        private ItemsController itemsController;
        private InventoryController inventoryController;
        private FightController fightController;
        private LevelGamesController levelGamesController;
        private int level;
        private GameResultView gameResultView;

        public GameController() {
            level = 0;
            mapController = new MapController(level);
            levelGamesController = new LevelGamesController();
            itemsController = new ItemsController();
            playerController = new PlayerController();
            inventoryController = new InventoryController(playerController.Player.Inventory);
            fightController = new FightController(playerController);
            gameResultView = new GameResultView();
        }


        public void Launch() {
            gameResultView.DisplayGameResult(StartGame());
        }

        public bool StartGame() {
            ConsoleKey key;
            level = 0;
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
                        inventoryController.OpenInventory(playerController);
                        break;
                    case ConsoleKey.D9:
                        Cheat();
                        break;
                    default:
                        renderMap = false;
                        break;
                }
                
                if(newPlayerPosX != playerPosX || newPlayerPosY != playerPosY) {
                    if (mapController.IsFreeChunk(newPlayerPosX, newPlayerPosY)) {
                        playerController.MakeMove(newPlayerPosX, newPlayerPosY);
                    } else if (mapController.IsItemBoxChunk(newPlayerPosX, newPlayerPosY)) {
                        playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                        playerController.MakeMove(newPlayerPosX, newPlayerPosY);
                        mapController.SetChunk(newPlayerPosX, newPlayerPosY, ChunkType.Floor);
                    } else if (mapController.IsOpponentChunk(newPlayerPosX, newPlayerPosY)) {
                        playerController.MakeMove(newPlayerPosX, newPlayerPosY);
                        bool playerWin = fightController.StartFight(level, false);
                        if (playerWin) {
                            playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                            mapController.SetChunk(newPlayerPosX, newPlayerPosY, ChunkType.Floor);
                        } else {
                            
                        }
                        playerController.Player.Health = 100;
                    } else if (mapController.IsBossChunk(newPlayerPosX, newPlayerPosY)) {
                        playerController.MakeMove(newPlayerPosX, newPlayerPosY);
                        bool playerWin = fightController.StartFight(level, true);
                        if (playerWin) {
                            playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                            playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                            playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                            playerController.KeyAquired();
                            playerController.Player.Health = 100;
                        } else {
                            return false;
                        }
                    } else if (mapController.IsGateChunk(newPlayerPosX, newPlayerPosY)) {
                        if(playerController.HasKey()) {
                            playerController.KeyUsed();
                            bool canPass = levelGamesController.RunMiniGame(level);
                            if(canPass) {
                                if(level == 2) {
                                    return true;
                                }
                                mapController.LoadMap(++level);
                                playerController.Player.PosX = 3;
                                playerController.Player.PosY = 3;
                            } else if(level == 2) {
                                return false;
                            }
                        } else {
                            Console.WriteLine("You don't have a key! Defeat boss to aquire it.");
                            System.Threading.Thread.Sleep(1000);
                        }
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

        public void Cheat() {
            playerController.Player.Health = 1000;
            playerController.Player.BaseAttack = 1000;
            playerController.Player.BaseDefence = 1000;
            playerController.Player.BaseVisibility = 1000;
            playerController.KeyAquired();
            playerController.CalculateAttack();
            playerController.CalculateDefence();
            playerController.CalculateVisibility();
        }

    }
}
using EscapeGame.Controller;
using EscapeGame.Model;
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

        public enum Result {
            Win,
            Lost,
            Continue
        }

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
            gameResultView.DisplayGameResult(StartGame() == Result.Win);
        }

        public Result StartGame() {
            ConsoleKey key;
            level = 0;
            int newPlayerPosX, newPlayerPosY;
            mapController.RenderMap(playerController.Player);
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Escape)) {
                newPlayerPosX = playerController.Player.PosX;
                newPlayerPosY = playerController.Player.PosY;
                bool madeMove = true, renderMap = false;

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
                        madeMove = false;
                        renderMap = true;
                        break;
                    case ConsoleKey.D9:
                        Cheat();
                        madeMove = false;
                        renderMap = true;
                        break;
                    default:
                        continue;
                }
                
                if(madeMove && !mapController.isWallChunk(newPlayerPosX, newPlayerPosY)) {
                    Result result = PerformAction(newPlayerPosX, newPlayerPosY);
                    if(result != Result.Continue) {
                        return result;
                    }
                    mapController.RenderMap(playerController.Player);
                } else if(renderMap) {
                    mapController.RenderMap(playerController.Player);
                }
            }
            return Result.Lost;
        }

        private Result PerformAction(int newPlayerPosX, int newPlayerPosY) {
            if(mapController.IsFreeChunk(newPlayerPosX, newPlayerPosY) ||
                mapController.IsItemBoxChunk(newPlayerPosX, newPlayerPosY)) {
                playerController.MakeMove(newPlayerPosX, newPlayerPosY);
            }
            if (mapController.IsItemBoxChunk(newPlayerPosX, newPlayerPosY)) {
                return ItemboxAction(newPlayerPosX, newPlayerPosY);
            } else if (mapController.IsOpponentChunk(newPlayerPosX, newPlayerPosY)) {
                return FightOpponentAction(newPlayerPosX, newPlayerPosY);
            } else if (mapController.IsBossChunk(newPlayerPosX, newPlayerPosY)) {
                return FightBossAction(newPlayerPosX, newPlayerPosY);
            } else if (mapController.IsGateChunk(newPlayerPosX, newPlayerPosY)) {
                return GateAction();
            }
            return Result.Continue;
        }

        private Result ItemboxAction(int newPlayerPosX, int newPlayerPosY) {
            playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
            mapController.SetChunk(newPlayerPosX, newPlayerPosY, ChunkType.Floor);
            return Result.Continue;
        }


        private Result FightOpponentAction(int newPlayerPosX, int newPlayerPosY) {
            bool playerWin = fightController.StartFight(level, false);
            if (playerWin) {
                playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                mapController.SetChunk(newPlayerPosX, newPlayerPosY, ChunkType.Floor);
            }
            playerController.renewHealth();
            return Result.Continue;
        }

        private Result FightBossAction(int newPlayerPosX, int newPlayerPosY) {
            bool playerWin = fightController.StartFight(level, true);
            if (playerWin) {
                mapController.SetChunk(newPlayerPosX, newPlayerPosY, ChunkType.Floor);
                playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                playerController.Player.Inventory.AddItem(itemsController.GetRandomItem());
                playerController.KeyAquired();
                playerController.renewHealth();
                return Result.Continue;
            }
            return Result.Lost;
        }

        private Result GateAction() {
            if (playerController.HasKey()) {
                bool canPass = levelGamesController.RunMiniGame(level);
                if (canPass) {
                    playerController.KeyUsed();
                    if (level == 2) {
                        return Result.Win;
                    }
                    mapController.LoadMap(++level);
                    playerController.Player.PosX = 3;
                    playerController.Player.PosY = 3;
                } else if (level == 2) {
                    return Result.Lost;
                }
            }

            gameResultView.NoKeyMessage();
            return Result.Continue;
        }

        private void Cheat() {
            playerController.Player.Health = 1000;
            playerController.Player.BaseAttack = 1000;
            playerController.Player.BaseDefence = 1000;
            playerController.Player.BaseVisibility = 1000;
            playerController.KeyAquired();
            playerController.CalculateAttack();
            playerController.CalculateDefence();
            playerController.CalculateVisibility();
            switch(level) {
                case 0:
                    playerController.Player.PosX = 119;
                    playerController.Player.PosY = 7;
                    break;
                case 1:
                    playerController.Player.PosX = 118;
                    playerController.Player.PosY = 21;
                    break;
                case 2:
                    playerController.Player.PosX = 119;
                    playerController.Player.PosY = 28;
                    break;
            }
            
        }

    }
}
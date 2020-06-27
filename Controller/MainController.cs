using System;

namespace EscapeGame {
    public class MainController {

        public Menu MenuView { get; set; }

        public MainController() {
            MenuView = new Menu();
        }

        public void Launch() {
            Console.Clear();
            MenuView.PrintMenu();
            ConsoleKey inputKey;
            int chosenOption = 0;

            while(!(inputKey = MenuView.GetInputKey()).Equals(ConsoleKey.Enter)) {
                Console.Clear();
                if(inputKey.Equals(ConsoleKey.DownArrow)) {
                    chosenOption++;
                } else if(inputKey.Equals(ConsoleKey.UpArrow)) {
                    chosenOption--;
                }
                chosenOption = (chosenOption < 0) ? 3 : chosenOption % 4;
                MenuView.PrintMenu(chosenOption);
            }

            switch(chosenOption) {
                case 0:
                    GameController gameController = new GameController();
                    gameController.Launch();
                    break;
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                default:
                    return;
            }
        }
    }
}

using System;

namespace EscapeGame {
    public class MainController {

        public MenuView MenuView { get; set; }

        public MainController() {
            MenuView = new MenuView();
        }

        public void Launch() {
            MenuView.PrintMenu();
            ConsoleKey inputKey;
            int chosenOption = 0;

            while(!(inputKey = MenuView.GetInputKey()).Equals(ConsoleKey.Escape)) {
                switch (inputKey) {
                    case ConsoleKey.DownArrow:
                        chosenOption = ++chosenOption % 4;
                        break;
                    case ConsoleKey.UpArrow:
                        chosenOption = (--chosenOption < 0) ? 3 : chosenOption % 4;
                        break;
                    case ConsoleKey.Enter:
                        if(chosenOption == 3) {
                            return;
                        } else {
                            LaunchMenuOption(chosenOption);
                        }
                        break;
                }
                MenuView.PrintMenu(chosenOption);
            }
        }

        private void LaunchMenuOption(int option) {
            switch(option) {
                case 0:
                    GameController gameController = new GameController();
                    gameController.Launch();
                    break;
                case 1:
                    MenuView.PrintTutorialMenuOption();
                    break;
                case 2:
                    MenuView.PrintCreditsMenuOption();
                    break;
                default:
                    return;
            }
        } 
    }
}

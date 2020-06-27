namespace EscapeGame {

    class GameController {
        public Menu MenuView {
            get; set;
        }

        public GameController() {
            MenuView = new Menu();
        }


    }
}
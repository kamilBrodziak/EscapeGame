using System;
namespace EscapeGame {

    public class MenuView {

        public MenuView() { }

        public ConsoleKey GetInputKey() {
            return Console.ReadKey().Key;
        }

        public void PrintMenu(int option = 0) {
            Console.Clear();
            PrintMenuOption("Start game", option == 0);
            PrintMenuOption("Tutorial", option == 1);
            PrintMenuOption("Credits", option == 2);
            PrintMenuOption("Quit", option == 3);
        }

        public void PrintMenuOption(string text, bool isChosen = false) {
            Console.WriteLine(new String('█', 30));
            if (isChosen)
                Console.WriteLine(new String('█', 30));
            else
                Console.WriteLine('█' + new String(' ', 28) + '█');
            if (isChosen)
                Console.WriteLine(new String('█', (int)Math.Floor((26 - text.Length) / 2.0)) + "  " + text + "  " +
                    new String('█', (int)Math.Ceiling((26 - text.Length) / 2.0)));
            else
                Console.WriteLine('█' + new String(' ', (int)Math.Floor((28 - text.Length) / 2.0)) + text +
                    new String(' ', (int)Math.Ceiling((28 - text.Length) / 2.0)) + '█');
            if (isChosen)
                Console.WriteLine(new String('█', 30));
            else
                Console.WriteLine('█' + new String(' ', 28) + '█');
            Console.WriteLine(new String('█', 30));
            Console.WriteLine();
        }

        public void PrintTutorialMenuOption() {
            Console.WriteLine("Hello player!");
            Console.WriteLine("When you start the game, map will render.");
            Console.WriteLine();
            Console.WriteLine("MAP:");
            Console.WriteLine("You can move on map by pressing arrow keys.");
            Console.WriteLine("On the map you can find few different chunks.");
            Console.WriteLine("█ - wall, you can't pass through it.");
            Console.WriteLine("$ - itembox, you can get one item from it.");
            Console.WriteLine("O - opponent, when you enter that chunk fight with opponent will begin.");
            Console.WriteLine("B - boss, same as opponent, but when you loose - game over, when you win - you will aquire key.");
            Console.WriteLine("G - gate to another level. Key is required to pass.");
            Console.WriteLine();
            Console.WriteLine("FIGHT:");
            Console.WriteLine("Fight with opponent or boss is initialized when you enter O/B chunk.");
            Console.WriteLine("Fight is a series of questions. You must choose answer.");
            Console.WriteLine("You can choose answer by pressing arrow keys.");
            Console.WriteLine("When you choose your answer press Enter.");
            Console.WriteLine("If answer was correct you hit enemy.");
            Console.WriteLine("If answer was incorrect, enemy hit you.");
            Console.WriteLine("If you win a fight, you get one item for fight with opponent, three items and key for fight with boss.");
            Console.WriteLine("If you loose a fight, you can start again with opponent, but you loose whole game if you lost a fight with boss.");
            Console.WriteLine("You should fight with lots of opponents to get items, otherwise you will easily loose with boss.");
            Console.WriteLine();
            Console.WriteLine("INVENTORY:");
            Console.WriteLine("You can open and close inventory by pressing I key.");
            Console.WriteLine("You can navigate through inventory items by pressing up/down arrow keys.");
            Console.WriteLine("If you want to equip some item, select it and press Enter");
            Console.WriteLine();
            Console.WriteLine("ITEMS:");
            Console.WriteLine("Sword - increase your attack.");
            Console.WriteLine("Armor - increase your defence.");
            Console.WriteLine("Light - increase your visibility.");
            Console.WriteLine();
            Console.WriteLine("GATE, LEVELS:");
            Console.WriteLine("If you want to pass to next level, you should have a key.");
            Console.WriteLine("Key can be obtained after successful fight with boss.");
            Console.WriteLine("There are 3 levels, you start on level 1.");
            Console.WriteLine("Next levels have a different map, different mini game, and harder enemies.");
            Console.WriteLine("Mini games will start when you try to pass to another level.");
            Console.WriteLine("If you want to pass to next level, you must win mini game.");
            Console.WriteLine("If you loose, on first two levels nothing happens.");
            Console.WriteLine("Last level mini game is special, if you win it, you win game, if you lose - game over.");
            Console.WriteLine();
            Console.WriteLine("Good luck!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }

        public void PrintCreditsMenuOption() {
            Console.WriteLine("Project made by Kamil Brodziak.");
            Console.WriteLine("Made from scratch in 3 days (24 hours).");
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }
    }
}
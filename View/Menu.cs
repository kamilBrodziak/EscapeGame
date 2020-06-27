using System;
namespace EscapeGame {

    public class Menu {

        public Menu() { }

        public ConsoleKey GetInputKey() {
            return Console.ReadKey().Key;
        }

        public void PrintMenu(int option = 0) {
            PrintMenuOption("Start game", option == 0);
            PrintMenuOption("Tutorial", option == 1);
            PrintMenuOption("Credits", option == 2);
            PrintMenuOption("Quit", option == 3);
        }

        public void PrintMenuOption(string text, bool isChosen = false) {
            Console.WriteLine(new String('*', 30));
            if (isChosen)
                Console.WriteLine(new String('*', 30));
            else
                Console.WriteLine('*' + new String(' ', 28) + '*');
            if (isChosen)
                Console.WriteLine(new String('*', (int)Math.Floor((28 - text.Length) / 2.0)) + ' ' + text + ' ' +
                    new String('*', (int)Math.Ceiling((28 - text.Length) / 2.0)));
            else
                Console.WriteLine('*' + new String(' ', (int)Math.Floor((28 - text.Length) / 2.0)) + text +
                    new String(' ', (int)Math.Ceiling((28 - text.Length) / 2.0)) + '*');
            if (isChosen)
                Console.WriteLine(new String('*', 30));
            else
                Console.WriteLine('*' + new String(' ', 28) + '*');
            Console.WriteLine(new String('*', 30));
            Console.WriteLine();
        }
    }
}
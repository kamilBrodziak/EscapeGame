using System;

namespace EscapeGame.View {
    public class LevelGamesView {

        public string GetUserInput() {
            return Console.ReadLine();
        }

        public ConsoleKey GetUserKeyInput() {
            return Console.ReadKey().Key;
        }

        //
        // HOT N COLD MINI GAME
        //
        public void PrintHotNColdEntrance() {
            Console.Clear();
            Console.WriteLine("Hello, I am nameless AI who trapped you here.");
            Console.WriteLine("I want to test, if you are worthy of living, HA HA HA.");
            Console.WriteLine("Let's play a game! I am thinking about number from 0 to 100.");
            Console.WriteLine("What number is it? You have 5 tries to guess");
        }

        public void PrintHotNColdWrongAnswer(int triesLeft) {
            Console.WriteLine($"Wrong! Try again, you have {triesLeft} tries left");
        }

        public void PrintHotNColdResult(bool playerWon) {
            System.Threading.Thread.Sleep(4000);
            if (playerWon) {
                Console.WriteLine($"You won! Congratulations. We will meet again, now you can pass to another level.");

            } else {
                Console.WriteLine("Oh my dear, you lost! But don't worry, you can try again, taste my mercy, HA HA HA!");
            }
        }

        //
        // TIC TAC TOE MINI GAME
        //

        public void PrintTicTacToeEntrance() {
            Console.WriteLine("Hello again my dear!");
            Console.WriteLine("You are doing really really great!");
            Console.WriteLine("But you are sooooo slow.. I am bored again!");
            Console.WriteLine("Let's Play another game! You start!");
            Console.WriteLine("Use left/right arrow to choose your move and hit enter when you want to make that move!");
        }
    }
}

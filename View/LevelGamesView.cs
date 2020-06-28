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
            if (playerWon) {
                Console.WriteLine($"You won! Congratulations. We will meet again, now you can pass to another level.");

            } else {
                Console.WriteLine("Oh my dear, you lost! But don't worry, you can try again, taste my mercy, HA HA HA!");
            }
            System.Threading.Thread.Sleep(4000);
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

        public void PrintTicTacToeTable(char[] moves, int playerMove) {
            string[] empty = "          ;          ;          ;          ;          ;          ;          ;          ".Split(';');
            string[] x = "XX      XX; XX    XX ;  XX  XX  ;   XXXX   ;   XXXX   ;  XX  XX  ; XX    XX ;XX      XX".Split(';');
            string[] o = "  OOOOOO  ; OO    OO ;OO      OO;OO      OO;OO      OO;OO      OO; OO    OO ;  OOOOOO  ".Split('\n');
            Console.WriteLine(new String('█', 34));
            for (int i = 0; i < 3; ++i) {
                for(int j = 0; j < empty.Length; ++j) {
                    Console.Write('█');
                    for(int k = 0; k < 3; ++k) {
                        if (moves[i*3 + k] == ' ') {
                            if(i*3 + k == playerMove) {
                                Console.WriteLine(x[j]);
                            } else {
                                Console.WriteLine(empty[j]);
                            }
                        } else if (moves[i*3 +k] == 'X') {
                            Console.WriteLine(x[j]);
                        } else if (moves[i*3 + k] == 'O') {
                            Console.WriteLine(o[j]);
                        }
                        Console.Write('█');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(new String('█', 34));
            }
        }

        public void PrintTicTacToeResult(string result) {
            if(result == "win") {
                Console.WriteLine("Congratulations! You won again!");
                Console.WriteLine("Now you can go to last level of this game, see you soon, or not HA HA HA.");
            } else if(result == "lost") {
                Console.WriteLine("Oh my precious, you lost!");
                Console.WriteLine("But, like I said before, taste my mercy and try again!");
            } else {
                Console.WriteLine("Wow, fair game!");
                Console.WriteLine("Unfortunately if you want to pass that level, you must win!");
                Console.WriteLine("Try again!");
            }
            System.Threading.Thread.Sleep(4000);
        }
    }
}

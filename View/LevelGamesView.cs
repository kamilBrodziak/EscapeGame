using System;
using System.IO;

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

        public void PrintHotNColdWrongAnswer(int triesLeft, int guessNumber, int correctNumber) {
            string coldMeter = "Frozing";
            int diff = Math.Abs(correctNumber - guessNumber);
            if (diff < 2 ) {
                coldMeter = "Burns!";
            } else if(diff < 5) {
                coldMeter = "Hot!";
            } else if(diff < 10) {
                coldMeter = "Warm!";
            } else if(diff < 15) {
                coldMeter = "Cold!";
            } else if(diff < 20) {
                coldMeter = "Very Cold!";
            }
            Console.WriteLine($"{coldMeter}! Try again, you have {triesLeft} tries left");

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

        public void PrintTicTacToe(char[] moves, int playerMove, bool isPlayerTurn) {
            Console.Clear();
            PrintTicTacToeEntrance();
            PrintTicTacToeTable(moves, playerMove, isPlayerTurn);
        }
        public void PrintTicTacToeEntrance() {
            Console.Clear();
            Console.WriteLine("Hello again my dear!");
            Console.WriteLine("You are doing really really great!");
            Console.WriteLine("But you are sooooo slow.. I am bored again!");
            Console.WriteLine("Let's Play another game! You start!");
            Console.WriteLine("Use left/right arrow to choose your move and hit enter when you want to make that move!");
        }

        public void PrintTicTacToeTable(char[] moves, int playerMove, bool isPlayerTurn) {
            string[] empty = "          ;          ;          ;          ;          ;          ;          ;          ".Split(';');
            string[] x = "XX      XX; XX    XX ;  XX  XX  ;   XXXX   ;   XXXX   ;  XX  XX  ; XX    XX ;XX      XX".Split(';');
            string[] o = "  OOOOOO  ; OO    OO ;OO      OO;OO      OO;OO      OO;OO      OO; OO    OO ;  OOOOOO  ".Split(';');
            Console.WriteLine(new String('█', 34));
            for (int i = 0; i < 3; ++i) {
                for(int j = 0; j < empty.Length; ++j) {
                    Console.Write('█');
                    for(int k = 0; k < 3; ++k) {
                        if (moves[i*3 + k] == ' ') {
                            if(i*3 + k == playerMove && isPlayerTurn) {
                                Console.Write(x[j]);
                            } else {
                                Console.Write(empty[j]);
                            }
                        } else if (moves[i*3 +k] == 'X') {
                            Console.Write(x[j]);
                        } else if (moves[i*3 + k] == 'O') {
                            Console.Write(o[j]);
                        }
                        Console.Write('█');
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(new String('█', 34));
            }
            if (!isPlayerTurn) {
                Console.WriteLine("Now it's my turn, be afraid HA HA HA!");
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


        //
        // HANGMAN MINI GAME
        //
        public void PrintHangmanEntrance() {
            Console.WriteLine("Great job my friend! You have come so far!");
            Console.WriteLine("Now it's time for your final test, your live forever or die now chance!");
            Console.WriteLine("You will play hangman! I will ask you a riddle and you have 6 chances to guess all word letters.");
            Console.WriteLine("You should provide only one letter at a time.");
        }

        public void PrintHangmanWrongInput() {
            Console.WriteLine("You should provide only one letter at a time!");
        }
        public void PrintHangman(int round, string riddle, char[] playerAnswerChars) {
            Console.Clear();
            PrintHangmanEntrance();
            StreamReader srLogo = new StreamReader($"files/miniGames/hangman/logo.txt");
            while (!srLogo.EndOfStream) {
                Console.WriteLine(srLogo.ReadLine());
            }
            Console.WriteLine();
            Console.WriteLine(riddle);
            Console.WriteLine();
            StreamReader sr = new StreamReader($"files/miniGames/hangman/{round}.txt");
            while(!sr.EndOfStream) {
                Console.WriteLine(sr.ReadLine());
            }

            Console.WriteLine();
            foreach(char c in playerAnswerChars) {
                if(c == ' ') {
                    Console.Write("   ");
                } else {
                    Console.Write($"{c} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"You have {round} tries left!");
        }

        public void PrintHangmanResult(bool result) {
            if(result) {
                Console.WriteLine("Excellent job! You passed final test and now you are free!");
                Console.WriteLine("I'm proud of you my friend!");
            } else {
                Console.WriteLine("Oh my dear, you lost!");
                Console.WriteLine("Now your life is my HA HA HA!");
            }
            System.Threading.Thread.Sleep(3000);
        }
    }
}

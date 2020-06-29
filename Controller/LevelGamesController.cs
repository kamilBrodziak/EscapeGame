
using EscapeGame.DAO;
using EscapeGame.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeGame.Controller {
    class LevelGamesController {
        private LevelGamesView levelGamesView { get; set; }
        private List<string[]> hangmanRiddles;

        public LevelGamesController() {
            levelGamesView = new LevelGamesView();
            hangmanRiddles = LevelGamesDAO.GetHangmanRiddles();
        }
        public bool RunMiniGame(int level) {
            switch(level) {
                case 1:
                    return TicTacToe();
                case 2:
                    return Hangman();
                case 0:
                default:
                    return HotNCold();
            }
        }

        public bool HotNCold() {
            levelGamesView.PrintHotNColdEntrance();
            Random rnd = new Random();
            int number = rnd.Next(0, 100);
            string userInput;
            for(int i = 1; i <= 5; ++i) {
                userInput = levelGamesView.GetUserInput();
                int guessedNumber;
                if(int.TryParse(userInput, out guessedNumber)) {
                    if (guessedNumber != number) {
                        levelGamesView.PrintHotNColdWrongAnswer(5 - i, guessedNumber, number);
                    } else {
                        levelGamesView.PrintHotNColdResult(true);
                        return true;
                    }
                } else {
                    levelGamesView.PrintHotNColdWrongAnswer(5 - i, -1000, number);
                }
                
            }
            levelGamesView.PrintHotNColdResult(false);
            return false;
        }

        public bool TicTacToe() {
            char[] moves = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            List<int> availableMoves = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            levelGamesView.PrintTicTacToeEntrance();
            for(int i = 0; i < moves.Length; ++i) {
                System.Threading.Thread.Sleep(2000);
                int playerChoose = 0;
                bool isPlayerTurn = i % 2 == 0;
                levelGamesView.PrintTicTacToe(moves, availableMoves[playerChoose], isPlayerTurn);
                if (isPlayerTurn) {
                    ConsoleKey key;
                    while(!(key = levelGamesView.GetUserKeyInput()).Equals(ConsoleKey.Enter)) {
                        if(key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow) {
                            if (key == ConsoleKey.LeftArrow) {
                                playerChoose = playerChoose - 1 >= 0 ? playerChoose - 1 : availableMoves.Count - 1;
                            } else if (key == ConsoleKey.RightArrow) {
                                playerChoose = playerChoose + 1 < availableMoves.Count ? playerChoose + 1 : 0;
                            }
                            levelGamesView.PrintTicTacToe(moves, availableMoves[playerChoose], isPlayerTurn);
                        }
                    }

                } else {
                    Random rnd = new Random();
                    playerChoose = rnd.Next(0, availableMoves.Count);
                }
                moves[availableMoves[playerChoose]] = isPlayerTurn ? 'X' : 'O';
                if(CheckIfWin(moves)) {
                    levelGamesView.PrintTicTacToe(moves, availableMoves[playerChoose], isPlayerTurn);
                    if (isPlayerTurn) {
                        levelGamesView.PrintTicTacToeResult("win");
                        return true;
                    } else {
                        levelGamesView.PrintTicTacToeResult("lost");
                        return false;
                    }
                }
                availableMoves.RemoveAt(playerChoose);
            }
            levelGamesView.PrintTicTacToeResult("tie");
            return false;
        }

        private bool CheckIfWin(char[] moves) {
            int[][] movesToCheck = new int[8][] {
                new int[3]{0, 2, 1 }, new int[3]{3, 5, 1 }, new int[3]{6, 8, 1 }, // on X axis
                new int[3]{0, 6, 3 }, new int[3]{1, 7, 3 }, new int[3]{2, 8, 3 }, // on Y axis
                new int[3]{0, 8, 4 }, new int[3]{2, 6, 2 } // diagonals
            };
            for (int i = 0; i < movesToCheck.Length; ++i) {
                if (CheckMoves(moves, movesToCheck[i][0], movesToCheck[i][1], movesToCheck[i][2])) 
                    return true;
            }
            return false;
        }

        private bool CheckMoves(char[] moves, int iterationStart, int maxLength, int iterationStep) {
            int x = 0, y = 0;
            for (int i = iterationStart; i <= maxLength; i += iterationStep) {
                if(moves[i] == 'X') {
                    x++;
                } else if(moves[i] == 'O') {
                    y++;
                }
            }

            return x == 3 || y == 3;
        }


        public bool Hangman() {
            Random rnd = new Random();
            string[] riddle = hangmanRiddles[rnd.Next(0, hangmanRiddles.Count)];
            string question = riddle[0];
            char[] riddleAnswerChars = riddle[1].ToUpper().ToCharArray();
            char[] playerAnswerChars = new char[riddleAnswerChars.Length];
            for(int j = 0; j < riddleAnswerChars.Length; ++j) {
                if(riddleAnswerChars[j] == ' ') {
                    playerAnswerChars[j] = ' ';
                } else {
                    playerAnswerChars[j] = '_';
                }
            }
            int i = 6;
            while (i > 0) {
                levelGamesView.PrintHangman(i, question, playerAnswerChars);
                string userInput = levelGamesView.GetUserInput().ToUpper();
                bool isGuess = false;
                if (userInput.Length > 1 || userInput.Length == 0) {
                    levelGamesView.PrintHangmanWrongInput();
                } else {
                    for (int j = 0; j < riddleAnswerChars.Length; ++j) {
                        if(riddleAnswerChars[j] == userInput[0] && playerAnswerChars[j] != userInput[0]) {
                            playerAnswerChars[j] = userInput[0];
                            isGuess = true;
                        }
                    }
                    if(!isGuess)
                        --i;
                    if(Enumerable.SequenceEqual(riddleAnswerChars, playerAnswerChars)) {
                        levelGamesView.PrintHangman(i, question, playerAnswerChars);
                        levelGamesView.PrintHangmanResult(true);
                        return true;
                    }
                }
            }
            levelGamesView.PrintHangman(i, question, playerAnswerChars);
            levelGamesView.PrintHangmanResult(false);
            return false;
        }
    }
}

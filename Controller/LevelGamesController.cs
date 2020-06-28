
using EscapeGame.View;
using System;

namespace EscapeGame.Controller {
    class LevelGamesController {
        private LevelGamesView levelGamesView { get; set; }

        public LevelGamesController() {
            levelGamesView = new LevelGamesView();
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
            for(int i = 1; i <= 5; ++i) {
                if(levelGamesView.GetUserInput() != $"{number}") {
                    levelGamesView.PrintHotNColdWrongAnswer(5 - i);
                } else {
                    levelGamesView.PrintHotNColdResult(true);
                    return true;
                }
            }
            levelGamesView.PrintHotNColdResult(false);
            return false;
        }

        public bool TicTacToe() {
            int[] moves = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //levelGamesView.Print
            return false;
        }

        public bool Hangman() {
            return false;
        }
    }
}

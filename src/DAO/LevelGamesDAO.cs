using System;
using System.Collections.Generic;
using System.IO;

namespace EscapeGame.DAO {
    class LevelGamesDAO {
        public static List<string[]> GetHangmanRiddles() {
            StreamReader sr = new StreamReader("src/files/miniGames/hangman/riddles.txt");
            List<string[]> riddles = new List<string[]>(); 
            while(!sr.EndOfStream) {
                string[] riddle = sr.ReadLine().Split(';');
                riddles.Add(riddle);
            }
            return riddles;
        }
    }
}

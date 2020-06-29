using System;
using System.IO;

namespace EscapeGame.View {
    class GameResultView {

        public void DisplayGameResult(bool isWin) {
            StreamReader sr;
            Console.Clear();
            if(isWin) {
                sr = new StreamReader("src/files/won.txt");
            } else {
                sr = new StreamReader("src/files/lost.txt");
            }

            while(!sr.EndOfStream) {
                Console.WriteLine(sr.ReadLine());
            }

            System.Threading.Thread.Sleep(5000);
        }

        public void NoKeyMessage() {
            Console.WriteLine("You don't have a key! Defeat boss to aquire it.");
            System.Threading.Thread.Sleep(1000);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EscapeGame.View {
    class GameResultView {

        public void DisplayGameResult(bool isWin) {
            StreamReader sr;
            Console.Clear();
            if(isWin) {
                sr = new StreamReader("files/won.txt");
            } else {
                sr = new StreamReader("files/lost.txt");
            }

            while(!sr.EndOfStream) {
                Console.WriteLine(sr.ReadLine());
            }

            System.Threading.Thread.Sleep(5000);
        }
    }
}

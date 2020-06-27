using System;

namespace EscapeGame {
    class PlayerController {
        public Player Player { get; set; }

        public PlayerController() {
            Player = new Player();
        }

        public bool MakeMove(int posX, int posY) {
            bool makedMove = false;
            if(posX != Player.PosX) {
                Player.PosX = posX;
                makedMove = true;
            }

            if(posY != Player.PosY) {
                Player.PosY = posY;
                makedMove = true;
            }
            return makedMove;
        }
    }
}

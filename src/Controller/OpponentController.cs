using EscapeGame.Model;
using System;

namespace EscapeGame.Controller {
    class OpponentController {
        public Opponent Opponent { get; set; }

        public OpponentController() {
           
        }

        public int ReceiveDamage(int damage) {
            int realDamage = (Opponent.Defence > damage) ? 0 : damage - Opponent.Defence;
            Opponent.Health -= realDamage;
            return realDamage;
        }

        public int GenerateAttack() {
            return Opponent.Attack;
        }

        public void generateNewOpponent(int level, bool isBoss) {
            int health = 0, defence = 0, attack = 0;
            Random rnd = new Random();
            switch(level) {
                case 0:
                    health = (!isBoss) ? rnd.Next(40, 60) : rnd.Next(100, 120);
                    defence = (!isBoss) ? rnd.Next(0, 6) : rnd.Next(6, 10);
                    attack = (!isBoss) ? rnd.Next(15, 25) : rnd.Next(50, 70);
                    break;
                case 1:
                    health = (!isBoss) ? rnd.Next(60, 100) : rnd.Next(150, 180);
                    defence = (!isBoss) ? rnd.Next(10, 14) : rnd.Next(14, 18);
                    attack = (!isBoss) ? rnd.Next(30, 50) : rnd.Next(70, 90);
                    break;
                case 2:
                    health = (!isBoss) ? rnd.Next(100, 140) : rnd.Next(180, 240);
                    defence = (!isBoss) ? rnd.Next(18, 22) : rnd.Next(22, 26);
                    attack = (!isBoss) ? rnd.Next(50, 80) : rnd.Next(90, 120);
                    break;
            }
            Opponent = new Opponent(health, defence, attack, isBoss);
        }
    }
}

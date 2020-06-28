namespace EscapeGame.Model {
    public class Opponent {
        public int Health { get; set; }
        public int Defence { get; set; }
        public int Attack { get; set; }
        public bool IsBoss { get; set; }
        public Opponent(int health, int defence, int attack, bool isBoss) {
            Health = health;
            Defence = defence;
            Attack = attack;
            IsBoss = isBoss;
        }
    }
}

namespace EscapeGame {

    public class Player {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Inventory Inventory { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Visibility { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefence { get; set; }
        public int BaseVisibility { get; set; }
        public bool HasKey { get; set; }
        

        public Player() {
            HasKey = false;
            Health = 100;
            Attack = 10;
            Defence = 5;
            BaseVisibility = 5;
            BaseAttack = 10;
            BaseDefence = 5;
            Visibility = BaseVisibility;
            Attack = BaseAttack;
            Defence = BaseDefence;
            PosX = 3;
            PosY = 3;
            Inventory = new Inventory();
        }
    }
}
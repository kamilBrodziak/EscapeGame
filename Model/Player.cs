namespace EscapeGame {

    public class Player {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Inventory Inventory { get; set; }
        public float Health { get; set; }
        

        public Player() {
            Health = 100.0f;
            PosX = 3;
            PosY = 3;
            Inventory = new Inventory();
        }
    }
}
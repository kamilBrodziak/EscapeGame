namespace EscapeGame.Model {
    public class Item {
        public int Stat { get; set; }

        public int ID { get; set; }
        public ItemType Type { get; set; }

        public string Name { get; set; }

        public Item(int id, int stat, ItemType itemType, string name) {
            Stat = stat;
            Type = itemType;
            Name = name;
            ID = id;
        }
    }
}
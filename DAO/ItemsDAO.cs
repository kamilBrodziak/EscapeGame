using System.Collections.Generic;
using System.IO;

namespace EscapeGame {
    public class ItemsDAO {
        public static Dictionary<int, Item> LoadItems() {
            Dictionary<int, Item> items = new Dictionary<int, Item>();
            StreamReader sr = new StreamReader("View/files/items.txt");
            string line;

            while ((line = sr.ReadLine()) != null) {
                string[] properties = line.Split(';');
                int id = int.Parse(properties[0]);
                ItemType type;
                switch (properties[0]) {
                    case "helmet":
                        type = ItemType.Helmet;
                        break;
                    case "chest":
                        type = ItemType.Chest;
                        break;
                    case "shoulder":
                        type = ItemType.Shoulder;
                        break;
                    case "gloves":
                        type = ItemType.Gloves;
                        break;
                    case "boots":
                        type = ItemType.Boots;
                        break;
                    case "sword":
                        type = ItemType.Sword;
                        break;
                    case "light":
                    default:
                        type = ItemType.Light;
                        break;
                }
                items.Add(id, new Item(id, int.Parse(properties[2]), type, properties[3]));
            }
            return items;
        }

    }
}

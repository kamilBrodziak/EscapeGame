using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeGame.Controller {
    public class ItemsController {
        public Dictionary<int, Item> items;

        public ItemsController() {
            items = ItemsDAO.LoadItems();
        }

        public Item GetRandomItem() {
            Random rnd = new Random();

            Item item = items[rnd.Next(0, items.Count)];
            items.Remove(item.ID);
            return item;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace EscapeGame {
    public class Inventory {
        public Dictionary<int, Item> Items { get; set; }
        public Dictionary<ItemType, Item> EquipedItems { get; set; }

        public Inventory() {
            Items = new Dictionary<int, Item>();
            EquipedItems = new Dictionary<ItemType, Item>();
            EquipedItems[ItemType.Helmet] = null;
            EquipedItems[ItemType.Chest] = null;
            EquipedItems[ItemType.Shoulder] = null;
            EquipedItems[ItemType.Gloves] = null;
            EquipedItems[ItemType.Boots] = null;
            EquipedItems[ItemType.Light] = null;
            EquipedItems[ItemType.Sword] = null;
        }

        public void AddItem(Item item) {
            Items[item.ID] = item;
        }

        public int GetLightStat() {
            return (EquipedItems[ItemType.Light] == null) ? 3 : 3 + EquipedItems[ItemType.Light].Stat;
        }

        public void EquipItem(Item item) {
            if(EquipedItems[item.Type] != null) {
                Items.Add(EquipedItems[item.Type].ID, EquipedItems[item.Type]);
            }
            Items.Remove(item.ID);
            Console.WriteLine(item.Type);
            EquipedItems[item.Type] = item;
        }
    }
}
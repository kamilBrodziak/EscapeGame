using EscapeGame.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeGame.Controller {
    class InventoryController {
        private Inventory inventory;
        private InventoryView inventoryView;
        private int printItemCount = 5;

        public InventoryController(Inventory inv) {
            inventory = inv;
            inventoryView = new InventoryView();
        }

        public void OpenInventory() {
            ConsoleKey key;
            int cursorPos = 0;
            bool printInv = true;
            List<Item> items = inventory.Items.Values.ToList();
            Item[] itemsToPrint = items.Take(Math.Min(items.Count, printItemCount)).ToArray();
            inventoryView.printInventory(inventory.EquipedItems, itemsToPrint,
                        10, 10, 5, Math.Min(cursorPos, printItemCount - 1));
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.I)) {
                printInv = true;
                switch (key) {
                    case ConsoleKey.UpArrow:
                        cursorPos = changeCursorPos(--cursorPos);
                        break;
                    case ConsoleKey.DownArrow:
                        cursorPos = changeCursorPos(++cursorPos);
                        break;
                    case ConsoleKey.Enter:
                        inventory.EquipItem(items[cursorPos]);
                        items = inventory.Items.Values.ToList();
                        if (inventory.Items.Count == cursorPos) {
                            cursorPos--;
                        }
                        break;
                    default:
                        printInv = false;
                        break;
                }
                if(printInv) {
                    if(cursorPos > printItemCount - 1) {
                        itemsToPrint = items.Skip(cursorPos - printItemCount + 1).Take(printItemCount).ToArray();
                    } else {
                        itemsToPrint = items.Take(printItemCount).ToArray();
                    }
                    inventoryView.printInventory(inventory.EquipedItems, itemsToPrint,
                        10, 10, 5, Math.Min(cursorPos, printItemCount - 1));
                }
            }

            
        }
        private int changeCursorPos(int newCursorPos) {
            if(newCursorPos > inventory.Items.Count - 1) {
                return 0;
            }

            if(newCursorPos < 0) {
                return inventory.Items.Count - 1;
            }

            return newCursorPos;
        }
    }
}
 
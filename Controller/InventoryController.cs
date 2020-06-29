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

        public void OpenInventory(PlayerController playerController) {
            ConsoleKey key;
            int cursorPos = 0;
            List<Item> items = inventory.Items.Values.ToList();
            Item[] itemsToPrint = items.Take(Math.Min(items.Count, printItemCount)).ToArray();
            inventoryView.printInventory(inventory.EquipedItems, itemsToPrint, inventory.HasKey,
                        playerController.Player, Math.Min(cursorPos, printItemCount - 1));
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.I)) {
                switch (key) {
                    case ConsoleKey.UpArrow:
                        cursorPos = changeCursorPos(--cursorPos);
                        break;
                    case ConsoleKey.DownArrow:
                        cursorPos = changeCursorPos(++cursorPos);
                        break;
                    case ConsoleKey.Enter:
                        EquipItem(playerController, items, ref cursorPos);
                        break;
                    default:
                        continue;
                }
                if(cursorPos > printItemCount - 1) {
                    itemsToPrint = items.Skip(cursorPos - printItemCount + 1).Take(printItemCount).ToArray();
                } else {
                    itemsToPrint = items.Take(printItemCount).ToArray();
                }
                inventoryView.printInventory(inventory.EquipedItems, itemsToPrint, inventory.HasKey,
                    playerController.Player, Math.Min(cursorPos, printItemCount - 1));
            }
        }

        private void EquipItem(PlayerController playerController, List<Item> items, ref int cursorPos) {
            Item item = items[cursorPos];
            inventory.EquipItem(item);
            if (item.Type == ItemType.Light) {
                playerController.CalculateVisibility();
            } else if (item.Type == ItemType.Sword) {
                playerController.CalculateAttack();
            } else {
                playerController.CalculateDefence();
            }
            items = inventory.Items.Values.ToList();
            if (inventory.Items.Count == cursorPos) {
                cursorPos--;
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
 
using System;
using System.Collections.Generic;

namespace EscapeGame.View {
    public class InventoryView {
        public void printInventory(Dictionary<ItemType, Item> equiped, Item[] items,
            int baseDefence, int baseAttack, int baseVisibility, int cursorPos) {
            Console.Clear();
            int helmet = equiped[ItemType.Helmet] != null ? equiped[ItemType.Helmet].Stat : 0;
            int shoulder = equiped[ItemType.Shoulder] != null ? equiped[ItemType.Shoulder].Stat : 0;
            int gloves = equiped[ItemType.Gloves] != null ? equiped[ItemType.Gloves].Stat : 0;
            int chest = equiped[ItemType.Chest] != null ? equiped[ItemType.Chest].Stat : 0;
            int boots = equiped[ItemType.Boots] != null ? equiped[ItemType.Boots].Stat : 0;
            int sword = equiped[ItemType.Sword] != null ? equiped[ItemType.Sword].Stat : 0;
            int light = equiped[ItemType.Light] != null ? equiped[ItemType.Light].Stat : 0;
            int defence = helmet + shoulder + gloves + chest + boots + baseDefence;
            int attack = sword + baseAttack;
            int visiblitiy = light + baseVisibility;
            string helmetStr = $" Helmet: {helmet} ",
                shoulderStr = $" Shoulder: {shoulder} ",
                glovesStr = $" Gloves: {gloves} ",
                chestStr = $" Chest: {chest} ",
                bootsStr = $" Boots: {boots} ",
                swordStr = $" Sword: {sword} ",
                lightStr = $" Light: {light} ",
                defenceStr = $" Defence: {defence} ",
                attackStr = $" Attack: {attack} ",
                visibilityStr = $" Visibility: {visiblitiy} ";

            Console.WriteLine(new String('█', 100));
            Console.WriteLine(new String('█', 100));
            Console.WriteLine($"██   {helmetStr}{new String(' ', 22 - helmetStr.Length)}█" +
                $"{shoulderStr}{new String(' ', 22 - shoulderStr.Length)}█" +
                $"{glovesStr}{new String(' ', 22 - glovesStr.Length)}█" +
                $"{chestStr}{new String(' ', 21 - chestStr.Length)}   ██");
            Console.WriteLine($"██   {bootsStr}{new String(' ', 22 - bootsStr.Length)}█" +
                $"{swordStr}{new String(' ', 22 - swordStr.Length)}█" +
                $"{lightStr}{new String(' ', 22 - lightStr.Length)}█" +
                $"{new String(' ', 21)}   ██");

            Console.WriteLine(new String('█', 100));
            Console.WriteLine($"██   {defenceStr}{new String(' ', 29 - defenceStr.Length)}█" +
                $"{attackStr}{new String(' ', 29 - attackStr.Length)}█" +
                $"{visibilityStr}{new String(' ', 30 - visibilityStr.Length)}   ██");
            Console.WriteLine(new String('█', 100));
            Console.WriteLine(new String('█', 100));

            Console.WriteLine($"██   {new String(' ', 90)}   ██");
            Console.WriteLine($"██   Name{new String(' ', 66)}Stat{new String(' ', 16)}   ██");
            Console.WriteLine($"██   {new String(' ', 90)}   ██");
            Console.WriteLine(new String('█', 100));
            for(int i = 0; i < items.Length; ++i) {
                Console.WriteLine(new String('█', 100));
                string name = $" {items[i].Name} ";
                string stat = $" {items[i].Stat} ";
                if (i == cursorPos) {

                    Console.WriteLine($"█████{new String(' ', 90)}█████");
                    Console.WriteLine($"█████  {name}{new String(' ', 68 - name.Length)}{stat}{new String(' ', 18 - stat.Length)}  █████");
                    Console.WriteLine($"█████{new String(' ', 90)}█████");

                } else {
                    Console.WriteLine($"██   {new String(' ', 90)}   ██");
                    Console.WriteLine($"██   {name}{new String(' ', 70 - name.Length)}{stat}{new String(' ', 20 - stat.Length)}   ██");
                    Console.WriteLine($"██   {new String(' ', 90)}   ██");
                }
            }
            Console.WriteLine(new String('█', 100));
            Console.WriteLine(new String('█', 100));
        }
    }


}

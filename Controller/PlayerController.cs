using System;

namespace EscapeGame {
    public class PlayerController {
        public Player Player { get; set; }

        public PlayerController() {
            Player = new Player();
        }

        public int GenerateAttack() {
            return Player.Attack;
        }

        public int ReceiveDamage(int damage) {
            int realDamage = (Player.Defence > damage) ? 0 : damage - Player.Defence;
            Player.Health -= realDamage;
            return realDamage;
        }

        public bool HasKey() {
            return Player.Inventory.HasKey;
        }

        public void KeyAquired() {
            Player.Inventory.HasKey = true;
        }

        public void KeyUsed() {
            Player.Inventory.HasKey = false;
        }

        public void CalculateAttack() {
            Player.Attack = Player.BaseAttack;
            if (Player.Inventory.EquipedItems[ItemType.Sword] != null) {
                Player.Attack += Player.Inventory.EquipedItems[ItemType.Sword].Stat;
            }
        }

        public void CalculateDefence() {
            Player.Defence = Player.BaseDefence;
            if (Player.Inventory.EquipedItems[ItemType.Helmet] != null) {
                Player.Defence += Player.Inventory.EquipedItems[ItemType.Helmet].Stat;
            }
            if (Player.Inventory.EquipedItems[ItemType.Chest] != null) {
                Player.Defence += Player.Inventory.EquipedItems[ItemType.Chest].Stat;
            }
            if (Player.Inventory.EquipedItems[ItemType.Shoulder] != null) {
                Player.Defence += Player.Inventory.EquipedItems[ItemType.Shoulder].Stat;
            }
            if (Player.Inventory.EquipedItems[ItemType.Gloves] != null) {
                Player.Defence += Player.Inventory.EquipedItems[ItemType.Gloves].Stat;
            }
            if (Player.Inventory.EquipedItems[ItemType.Boots] != null) {
                Player.Defence += Player.Inventory.EquipedItems[ItemType.Boots].Stat;
            }
        }

        public void CalculateVisibility() {
            Player.Visibility = Player.BaseVisibility;
            if (Player.Inventory.EquipedItems[ItemType.Light] != null) {
                Player.Visibility += Player.Inventory.EquipedItems[ItemType.Light].Stat;
            }
        } 
        public bool MakeMove(int posX, int posY) {
            bool makedMove = false;
            if(posX != Player.PosX) {
                Player.PosX = posX;
                makedMove = true;
            }

            if(posY != Player.PosY) {
                Player.PosY = posY;
                makedMove = true;
            }
            return makedMove;
        }
    }
}

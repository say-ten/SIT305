using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Player : Character
    {
        public int Floor { get; set; }
        public Dungeon Dungeon { get; set; }
        [SerializeField]
        Interactions interactions;
        public Region region;

        void Start()
        {
            Floor = 0;
            playerHealth = 100;
            playerMaxHealth = 500;
            playerAttack = 40;
            playerDefence = 20;
            Inventory = new List<string>();
            playerRoomIndex = new Vector2(2,2);
            UIController.OnPlayerStatChange();
            UIController.OnPlayerInventoryChange();
            this.Dungeon = region.Dungeon[(int)playerRoomIndex.x, (int)playerRoomIndex.y];
            this.Dungeon.Empty = true;
        }

        public void Direction(int direction)
        {
            if (Dungeon.Monster)
            {
                return;
            }
            if (direction == 0 && playerRoomIndex.y > 0)
            {
                Console.Instance.Entry("Moved north.");
                playerRoomIndex -= Vector2.up;
            }
            if (direction == 1 && playerRoomIndex.y < region.Dungeon.GetLength(1) - 1)
            {
                Console.Instance.Entry("Moved south.");
                playerRoomIndex -= Vector2.down;
            }
            if (direction == 2 && playerRoomIndex.x < region.Dungeon.GetLength(0) - 1)
            {
                Console.Instance.Entry("Moved east.");
                playerRoomIndex += Vector2.right;
            }
            if (direction == 3 && playerRoomIndex.x > 0)
            {
                Console.Instance.Entry("Moved west.");
                playerRoomIndex += Vector2.left;
            }
            if (this.Dungeon.RoomIndex != playerRoomIndex)
                Investigate();
        }

        public void Investigate()
        {
            this.Dungeon = region.Dungeon[(int)playerRoomIndex.x, (int)playerRoomIndex.y];

            Debug.Log(playerRoomIndex);
            interactions.ResetDynamicControls();
            if (this.Dungeon.Empty)
            {
                Console.Instance.Entry("This room is empty.");
            }
            else if (this.Dungeon.Chest != null)
            {
                interactions.StartChest();
                Console.Instance.Entry("Chest found, would you like to open it?");
            }
            else if (this.Dungeon.Monster != null)
            {
                Console.Instance.Entry("You are being attacked by a " + Dungeon.Monster.Description + "! Select an action!");
                interactions.StartFight();
            }
            else if (this.Dungeon.Exit)
            {
                interactions.StartExit();
                Console.Instance.Entry("Next floor located. Would you like to exit?");
            }
        }

        public void AddItem(string item)
        {
            Console.Instance.Entry("You found an item!");
            Inventory.Add(item);
            UIController.OnPlayerInventoryChange();
        }

        public override void damageTaken(int amount)
        {
            Console.Instance.Entry("You took damage!");
            base.damageTaken(amount);
            UIController.OnPlayerStatChange();
        }

        public override void Die()
        {
            Console.Instance.Entry("You died! Game over!");
            base.Die();
        }
    }
}

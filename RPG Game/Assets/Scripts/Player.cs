namespace RPGGame
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Player : Character
    {
        public int Floor { get; set; }

        public Dungeon Dungeon { get; set; }

        [SerializeField]
        internal Interactions interactions;

        public Region region;

        internal void Start()
        {
            Floor = 0;
            Health = 50;
            MaxHealth = 100;
            Attack = 15;
            Defence = 5;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2, 2);
            UIController.OnPlayerStatChange();
            UIController.OnPlayerInventoryChange();
            this.Dungeon = region.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
            this.Dungeon.Empty = true;
        }

        public void Navigation(int direction)
        {
            if (Dungeon.Monster)
            {
                return;
            }
            if (direction == 0 && RoomIndex.y > 0)
            {
                Console.Instance.Entry("Moved north.");
                RoomIndex -= Vector2.up;
            }
            if (direction == 1 && RoomIndex.y < region.Dungeon.GetLength(1) - 1)
            {
                Console.Instance.Entry("Moved south.");
                RoomIndex -= Vector2.down;
            }
            if (direction == 2 && RoomIndex.x < region.Dungeon.GetLength(0) - 1)
            {
                Console.Instance.Entry("Moved east.");
                RoomIndex += Vector2.right;
            }
            if (direction == 3 && RoomIndex.x > 0)
            {
                Console.Instance.Entry("Moved west.");
                RoomIndex += Vector2.left;
            }
            if (this.Dungeon.RoomIndex != RoomIndex)
                Investigate();
        }

        public void Investigate()
        {
            this.Dungeon = region.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];

            Debug.Log(RoomIndex);
            interactions.ResetDynamicControls();
            if (this.Dungeon.Empty)
            {
                Console.Instance.Entry("Looking around you're in a empty room.");
            }
            else if (this.Dungeon.Chest != null)
            {
                interactions.StartChest();
                Console.Instance.Entry("Chest found, open?");
            }
            else if (this.Dungeon.Monster != null)
            {
                Console.Instance.Entry("You are attacked by a " + Dungeon.Monster.Description + "! Select an action");
                interactions.StartFight();
            }
            else if (this.Dungeon.Exit)
            {
                interactions.StartExit();
                Console.Instance.Entry("Door to next floor found. Would you like to exit?");
            }
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
            UIController.OnPlayerInventoryChange();
        }

        public void AddItem(int item)
        {
            Inventory.Add(ItemDatabase.Instance.Items[item]);
            UIController.OnPlayerInventoryChange();
        }

        public override void Attacked(int hp)
        {
            Console.Instance.Entry("You have taken damage");
            base.Attacked(hp);
            UIController.OnPlayerStatChange();
        }

        public override void Dead()
        {
            Console.Instance.Entry("You have died. Game over!");
            base.Dead();
        }
    }
}
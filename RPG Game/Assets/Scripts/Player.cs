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

        //sets player stats at the beginning of game as well as floor number
        //calls to update the player status ui and inventory ui text
        //makes sure that the character spawn location has no monsters
        internal void Start()
        {
            Floor = 0;
            Health = 100;
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

        //creates 4 movement options for north, south, east and west
        //each direction is linked to a number which is inputted into the game buttons
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

        //checks current floor/roomindex location if the player has encountered anything
        //displays different text output for the different options if player has encountered something
        public void Investigate()
        {
            this.Dungeon = region.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];

            Debug.Log(RoomIndex);
            interactions.ResetDynamicControls();
            if (this.Dungeon.Empty)
            {
                Console.Instance.Entry("Searching, room empty");
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
                Console.Instance.Entry("Door found. Would you like to exit?");
            }
        }

        //adds item to player inventory
        public void AddItem(string item)
        {
            Inventory.Add(item);
            UIController.OnPlayerInventoryChange();
        }

        //adds item to player inventory
        public void AddItem(int item)
        {
            Inventory.Add(ItemDatabase.Instance.Items[item]);
            UIController.OnPlayerInventoryChange();
        }

        //calls the attacked funtion with how much damamge you have taken and updates player health
        public override void Attacked(int hp)
        {
            Console.Instance.Entry("You have taken damage");
            base.Attacked(hp);
            UIController.OnPlayerStatChange();
        }

        //calls the dead method and lets player know they have died.
        public override void Dead()
        {
            Console.Instance.Entry("You have died. Game over!");
            base.Dead();
        }
    }
}
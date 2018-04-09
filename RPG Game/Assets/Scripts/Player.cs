using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Player : Character
    {
        public int Floor { get; set; }

        // Use this for initialization
        void Start()
        {
            Floor = 0;
            Health = 30;
            Attack = 15;
            Defence = 5;
            Inventory = new List<string>();
            RoomIndex = new Vector2(2,2);
        }

        public void AddItem(string item)
        {
            Inventory.Add(item);
        }

        public override void TakeDamage(int amount)
        {
            Debug.Log("You have taken damage");
            base.TakeDamage(amount);
        }
    }
}

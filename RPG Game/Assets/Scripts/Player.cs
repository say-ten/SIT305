using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Player : Character
    {
        public int Floor { get; set; }

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

        public override void Attacked(int hp)
        {
            Debug.Log("You have taken damage");
            base.Attacked(hp);
        }
    }
}

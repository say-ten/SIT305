using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Boar : Monster
    {
        void Start()
        {
            Description = "Boar";
            Health = 25;
            Attack = 7;
            Defence = 5;

            if (Random.Range(0, 19) == 0)
            {
                Inventory.Add(ItemDatabase.Instance.Items[0]);
            }
        }
    }
}

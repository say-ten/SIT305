using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Monster1 : Monster
    {
        void Start()
        {
            Health = 0;
            Attack = 0;
            Defence = 0;
            Inventory.Add("item1");
        }
    }
}

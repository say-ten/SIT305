using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Lion : Monster
    {
        void Start()
        {
            Description = "Lion";
            Health = 40;
            Attack = 12;
            Defence = 7;
            Inventory.Add("Lion monster core");
        }
    }
}

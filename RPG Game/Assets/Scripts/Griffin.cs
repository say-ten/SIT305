using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Griffin : Monster
    {
        void Start()
        {
            Description = "Griffin";
            Health = 30;
            Attack = 10;
            Defence = 10;
            Inventory.Add("Griffin monster core");
            Inventory.Add("Blue Gem");
        }
    }
}

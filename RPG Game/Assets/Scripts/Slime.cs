using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Slime : Monster
    {
        void Start()
        {
            Health = 20;
            Attack = 5;
            Defence = 5;
            Inventory.Add("Slime monster core");
        }
    }
}

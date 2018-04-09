using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Slime : Monster
    {
        void Start()
        {
            Health = 0;
            Attack = 0;
            Defence = 0;
            Inventory.Add("Slime monster core");
        }
    }
}

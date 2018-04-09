using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Boar : Monster
    {
        void Start()
        {
            Health = 25;
            Attack = 7;
            Defence = 5;
            Inventory.Add("Boar monster core");
        }
    }
}

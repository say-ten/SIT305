using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Griffin : Monster
    {
        void Start()
        {
            Health = 30;
            Attack = 10;
            Defence = 5;
            Inventory.Add("Griffin monster core");
        }
    }
}

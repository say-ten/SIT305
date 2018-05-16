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
            monsterHealth = 30;
            monsterAttack = 20;
            monsterDefence = 10;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Slime : Monster
    {
        void Start()
        {
            Description = "Slime";
            monsterHealth = 10;
            monsterAttack = 5;
            monsterDefence = 10;
        }
    }
}

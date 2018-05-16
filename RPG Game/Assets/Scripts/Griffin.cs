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
            monsterHealth = 25;
            monsterAttack = 15;
            monsterDefence = 15;
        }
    }
}

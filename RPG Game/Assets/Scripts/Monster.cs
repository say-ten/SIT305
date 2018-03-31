using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Monster : Character
    {
        public override void Attacked(int hp)
        {
            base.Attacked(hp);
            Debug.Log("");
        }

        public override void Dead()
        {
            Debug.Log("You have killed the monster");
        }
    }
}

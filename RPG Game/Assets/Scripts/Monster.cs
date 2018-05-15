using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Monster : Character
    {
        public string Description { get; set; }

        public override void Attacked(int hp)
        {
            UIController.OnMonsterUpdate(this);
            base.Attacked(hp);
            Debug.Log("");
        }

        public override void Dead()
        {
            Console.Instance.Entry("You have killed the monster");
        }
    }
}

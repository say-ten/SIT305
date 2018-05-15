using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public interface IBaddie
    {
        void Cry();
        string Description { get; set; }
    }

    public class Monster : Character
    {
        public string Description { get; set; }

        public override void Attacked(int hp)
        {
            base.Attacked(hp);
            UIController.OnMonsterUpdate(this);
        }

        public void Cry()
        {
        }

        public override void Dead()
        {
            Health = MaxHealth;
            Console.Instance.Entry("You have killed the monster");
            Interactions.OnMonsterDead();
        }
    }
}

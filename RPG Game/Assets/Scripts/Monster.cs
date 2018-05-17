using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Monster
    {
        public string Description { get; set; }
        public int monsterHealth { get; set; }
        public int monsterMaxHealth { get; set; }
        public int monsterAttack { get; set; }
        public int monsterDefence { get; set; }
        public Vector2 monsterRoomIndex { get; set; }

        public virtual void damageTaken(int amount)
        {
            monsterHealth -= amount;
            if (monsterHealth <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Console.Instance.Entry("You killed the monster!");
        }
    }
}

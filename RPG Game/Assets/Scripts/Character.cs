using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Character : MonoBehaviour
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public Vector2 RoomIndex { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();

        public virtual void Attacked(int hp)
        {
            Health -= hp;
            if (Health <= 0)
            {
                Dead();
            }
        }

        public virtual void Dead()
        {
            Debug.Log("Game Over, You have died.");
        }
    }
}
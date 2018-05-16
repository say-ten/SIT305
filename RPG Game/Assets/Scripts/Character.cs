using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Character : MonoBehaviour
    {
        public int playerHealth { get; set; }
        public int playerMaxHealth { get; set; }
        public int playerAttack { get; set; }
        public int playerDefence { get; set; }
        public Vector2 playerRoomIndex { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();

        public virtual void damageTaken(int amount)
        {
            playerHealth -= amount;
            if (playerHealth <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Debug.Log("You died! Game over!");
        }
    }
}
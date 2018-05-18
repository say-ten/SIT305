namespace RPGGame
{
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class Character : MonoBehaviour
    {
        //public modifiers for all of the characters stats as well as the dungeon room and inventory list
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public Vector2 RoomIndex { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();

        //function that calculates what happens whenever the attacked method is called
        //player and monster takes damage and if health drops below 0 they die
        public virtual void Attacked(int hp)
        {
            Health -= hp;
            if (Health <= 0)
            {
                Dead();
            }
        }

        //internal log to show when player dies
        public virtual void Dead()
        {
            Debug.Log("Game Over, You have died.");
        }
    }
}
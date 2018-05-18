namespace RPGGame
{
    using System.Collections.Generic;
    using UnityEngine;

    public class MonsterDatabase : MonoBehaviour
    {
        public List<Monster> Monsters { get; set; } = new List<Monster>();
        public static MonsterDatabase Instance { get; set; }

        //loads all the monsters at the start of the game into the list and displays a internal log
        private void Awake()
        {
            Instance = this;
            foreach (Monster monster in GetComponents<Monster>())
            {
                Debug.Log("Monster Found");
                Monsters.Add(monster);
            }

            Monsters.AddRange(GetComponents<Monster>());
        }

        //randomizes a monster and calls it for when player encounters one
        public Monster GetRandomMonster()
        {
            return Monsters[Random.Range(0, Monsters.Count)];
        }
    }
}
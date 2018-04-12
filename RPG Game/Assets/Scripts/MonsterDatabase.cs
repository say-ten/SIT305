using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class MonsterDatabase : MonoBehaviour
    {
        public List<Monster> Monsters { get; set; } = new List<Monster>();
        public static MonsterDatabase Instance { get; set; }
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

        public Monster GetRandomEnemy()
        {
            return Monsters[Random.Range(0, Monsters.Count)];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class MonsterDatabase : MonoBehaviour
    {
        public List<Monster> monsterList { get; set; } = new List<Monster>();
        public static MonsterDatabase Instance { get; set; }
        private void Awake()
        {
            Instance = this;
            foreach (Monster monster in GetComponents<Monster>())
            {
                Debug.Log("A monster appeared!");
                monsterList.Add(monster);
            }

            monsterList.AddRange(GetComponents<Monster>());
        }

        public Monster GetRandomMonster()
        {
            return monsterList[Random.Range(0, monsterList.Count)];
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Dungeon : MonoBehaviour
    {
        public Chest Chest { get; set; }
        public Monster Monster { get; set; }
        public bool Exit { get; set; }
        public bool Empty { get; set; }
        public Vector2 RoomIndex { get; set; }

        public Dungeon(Chest chest, Monster monster, bool empty, bool exit)
        {
            this.Chest = chest;
            this.Monster = monster;
            this.Empty = empty;
            this.Exit = exit;
        }

        public Dungeon()
        {
            int roll = Random.Range(0,29);
            if (roll >= 0 && roll <= 9)
            {
                Monster = MonsterDatabase.Instance.GetRandomMonster();
                Monster.monsterRoomIndex = RoomIndex;
            }
            else if (roll >= 10 && roll <= 19)
            {
                Chest = new Chest();
            }
            else 
            {
                Empty = true;
            }

        }
    }
}
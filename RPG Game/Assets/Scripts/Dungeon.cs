﻿namespace RPGGame
{
    using UnityEngine;

    public class Dungeon : MonoBehaviour
    {
        //public modifiers for all things that can be found in the dungeon
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

        //this method decides if what you encounter on each roomindex is a monster, chest or empty
        public Dungeon()
        {
            int roll = Random.Range(0, 30);
            if (roll > 0 && roll < 6)
            {
                Monster = MonsterDatabase.Instance.GetRandomMonster();
                Monster.RoomIndex = RoomIndex;
            }
            else if (roll > 15 && roll < 20)
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
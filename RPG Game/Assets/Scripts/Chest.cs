using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Chest : MonoBehaviour
    {
        public Monster Monster { get; set; }
        public string Item { get; set; }
        public bool Trap { get; set; }
        public bool Potion { get; set; }

        public Chest()
        {
            if (Random.Range(0,7) == 2)
            {
                Trap = true;
            }
            else if (Random.Range(0,5) == 2)
            {
                Potion = true;
            }
            else if(Random.Range(0,5) == 2)
            {
                Monster = MonsterDatabase.Instance.GetRandomMonster();
            }
            else
            {
                //int itemToAdd = Random.Range(0, ItemDatabase.Instance.Items.Count);
                //Item = ItemDatabase.Instance.Items[itemToAdd];
            }
        }
    }
}
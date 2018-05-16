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
            if (Random.Range(0,9) == 0)
            {
                Trap = true;
            }
            else if (Random.Range(0,2) == 0)
            {
                Potion = true;
            }
            else if (Random.Range(0,4) == 0)
            {
                Monster = MonsterDatabase.Instance.GetRandomMonster();
            }
            else if (Random.Range(0, 49) == 0)
            {
                Item = ItemDatabase.Instance.itemList[4];
            }
            else
            {
                Debug.Log("The chest is empty!"); 
            }
        }
    }
}
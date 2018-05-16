using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<string> itemList { get; set; } = new List<string>();
        public static ItemDatabase Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

            itemList.Add("Blue Gem");
            itemList.Add("Red Gem");
            itemList.Add("Yellow Gem");
            itemList.Add("Green Gem");
            itemList.Add("Rainbow Gem");
        }
    }
}
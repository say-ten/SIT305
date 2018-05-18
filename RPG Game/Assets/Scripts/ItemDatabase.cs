namespace RPGGame
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ItemDatabase : MonoBehaviour
    {
        public List<string> Items { get; set; } = new List<string>();

        public static ItemDatabase Instance { get; private set; }

        //checks for existing item database then loads new one
        //adds items into the database for chest class
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

            Items.Add("Rainbow Gem");
        }
    }
}
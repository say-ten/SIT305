using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace RPGGame

{
    [System.Serializable]
    public class Boar : Monster
    {
        string filePath;
        string jsonString;

        void Start()
        {
            filePath = Application.streamingAssetsPath + "/monsterDatabase.json";
            jsonString = File.ReadAllText(filePath);
            Character Boar = JsonUtility.FromJson<Character>(jsonString);
            Description = "Boar";
            Health = Boar.Health;
            Attack = Boar.Attack;
            Defence = Boar.Defence;
            Inventory = Boar.Inventory;
        }

    }
}

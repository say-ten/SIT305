using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace RPGGame
{
    public class Boar : Monster
    {
        string filePath;
        string jsonString;

        void Start()
        {
            
            filePath = Application.streamingAssetsPath + "/monsterDatabase.json";
            jsonString = File.ReadAllText(filePath);
            Monster stats = JsonUtility.FromJson<Monster>(jsonString);
            Description = stats.Description;
            monsterHealth = stats.monsterHealth;
            monsterAttack = stats.monsterAttack;
            monsterDefence = stats.monsterDefence;

           // Description = "Boar";
            //monsterHealth = 20;
            //monsterAttack = 10;
            //monsterDefence = 5;
        }
    }
}

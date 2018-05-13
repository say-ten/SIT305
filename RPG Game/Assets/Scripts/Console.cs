using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class Console : MonoBehaviour
    {
        [SerializeField] Text logText;
        public static Console Instance { get; set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
        }

        public void Entry(string text)
        {
            logText.text += "\n" + text;
        }
    }
}

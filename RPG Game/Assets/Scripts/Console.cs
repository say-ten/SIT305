namespace RPGGame
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Console : MonoBehaviour
    {
        [SerializeField] internal Text logText;

        public static Console Instance { get; set; }

        //when the game laods this removes any previous console texts and creates a new one
        internal void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;
        }

        //when entry is called this prints text into the logText field in ui
        public void Entry(string text)
        {
            logText.text += "\n" + text;
        }
    }
}
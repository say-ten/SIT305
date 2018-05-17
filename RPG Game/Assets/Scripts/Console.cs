namespace RPGGame
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Console : MonoBehaviour
    {
        [SerializeField] internal Text logText;

        public static Console Instance { get; set; }

        internal void Awake()
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
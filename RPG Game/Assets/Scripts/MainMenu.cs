namespace RPGGame
{
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;

        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Debug.Log("Quit game");
            Application.Quit();
        }

        public void VolumeLevel(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }

        public void Mute()
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
namespace RPGGame
{
    using UnityEngine;
    using UnityEngine.Audio;
    using UnityEngine.SceneManagement;

    public class MainMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;

        //button to change scene when you press start game
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //button for exiting the game when pressed
        public void QuitGame()
        {
            Debug.Log("Quit game");
            Application.Quit();
        }

        //method for controling overall volume via a bar
        public void VolumeLevel(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }

        //toggle for muting/pausing background music
        public void Mute()
        {
            AudioListener.pause = !AudioListener.pause;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer; 
    public void VolumeLevel (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}

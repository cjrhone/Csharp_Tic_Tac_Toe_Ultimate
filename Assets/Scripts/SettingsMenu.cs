using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume) // float volume is dynamic value of slider 
    {
        audioMixer.SetFloat("volume", volume); //looks for exposed "volume" parameter we set in AudioMixer
    } 
}

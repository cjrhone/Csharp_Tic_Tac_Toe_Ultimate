using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sound 
{
   public AudioClip clip; // creates reference to audioclip
   public string name; // creates name input

   [Range(0f, 1f)] //creates slider with indicated range
   public float volume;

   [Range(.1f, 3f)]
   public float pitch;

   public bool loop;


   [HideInInspector] // hides inspector
   public AudioSource source; // creates audiosource reference ( for volume, pitch, etc ) 
   

}

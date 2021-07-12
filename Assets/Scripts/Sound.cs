using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class Sound 
{
   [Serializable]
   public enum SoundType {
      GameStart_VO,
      Title_VO,
      Tie,
      Tie_VO,
      Explode,
      Explode_VO,
      Obliteration,
      Obliteration_VO,
      Ready_VO,
      Victory,
      Back,
      oMove,
      xMove,
      Menu,
      Select, 
      Battle,
      Riser
   }

   public AudioClip clip; // creates reference to audioclip

   [Range(0f, 1f)] //creates slider with indicated range
   public float volume;

   [Range(.1f, 3f)]
   public float pitch;

   public bool loop;
   public SoundType soundType;


   [HideInInspector] // hides inspector
   public AudioSource source; // creates audiosource reference ( for volume, pitch, etc ) 
   
   public void PlaySound(){

   }

}

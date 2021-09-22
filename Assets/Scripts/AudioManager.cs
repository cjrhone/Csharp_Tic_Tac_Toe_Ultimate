using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; 

    public float fadeSpeed = 1f;

    public static AudioManager instance;

    public AudioSource backgroundMusic;
    public AudioSource soundEffects;
    public AudioSource voiceOver;

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene());
        Play(Sound.SoundType.Menu);
        Play(Sound.SoundType.Title_VO);
    }

    void Awake()
    {
        // AudioManager Singleton
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; //prevents other code from running before offing itself
        }

        DontDestroyOnLoad(gameObject);

        // foreach (Sound s in sounds)
        // {
        //     s.source = gameObject.AddComponent<AudioSource>();
        //     s.source.clip = s.clip;
            
        //     s.source.volume = s.volume;
        //     s.source.pitch = s.pitch;
        //     s.source.loop = s.loop;
        // }
        
    }

    public void PlaySelectSound(){
        Play(Sound.SoundType.Select);
    }

    public void Play (Sound.SoundType soundType)
    {
        Sound[] s = Array.FindAll<Sound>(sounds, sound => sound.soundType == soundType); //the sound => ... is called a lambda function 
        if (s == null || s.Length <= 0)
        {
            Debug.LogWarning($"Sound: {soundType} not found!");
            return;
        }

        Sound chosenSound = s[0];

        if(s.Length > 1){
            //Randomize 
            var count = s.Length;
            var clipToPlay = UnityEngine.Random.Range(0, count - 1);
            chosenSound = s[clipToPlay];
        }

        switch(chosenSound.soundType){
            case Sound.SoundType.Menu:
            case Sound.SoundType.Battle:
            //go into BG Music Audio Track
            backgroundMusic.Stop();
            SetAudioToTrack(backgroundMusic, chosenSound);
            backgroundMusic.Play();
            break;

            case Sound.SoundType.Title_VO:
            case Sound.SoundType.Tie_VO:
            case Sound.SoundType.GameStart_VO:
            case Sound.SoundType.Explode_VO:
            case Sound.SoundType.Obliteration_VO:
            case Sound.SoundType.XWin_VO:
            case Sound.SoundType.OWin_VO:
            // go into the Voice over VO Track
            voiceOver.Stop();
            SetAudioToTrack(voiceOver, chosenSound);
            voiceOver.Play();
            break;

            default: 
            // All other sounds go to SFX Track
            soundEffects.Stop();
            SetAudioToTrack(soundEffects, chosenSound);
            soundEffects.Play();
            break;
        }
    }

    void SetAudioToTrack (AudioSource audioSource, Sound soundToPlay){
        audioSource.clip = soundToPlay.clip;            
        audioSource.volume = soundToPlay.volume;
        audioSource.pitch = soundToPlay.pitch;
        audioSource.loop = soundToPlay.loop;
    }

    public void StopPlaying(Sound.SoundType soundType)
    {
        switch(soundType){
            case Sound.SoundType.Menu:
            case Sound.SoundType.Battle:
            //go into BG Music Audio Track
            backgroundMusic.Stop();
            break;

            case Sound.SoundType.Title_VO:
            case Sound.SoundType.Tie_VO:
            case Sound.SoundType.GameStart_VO:
            case Sound.SoundType.Explode_VO:
            case Sound.SoundType.Obliteration_VO:
            case Sound.SoundType.XWin_VO:
            case Sound.SoundType.OWin_VO:


            // go into the Boice over VO Track
            voiceOver.Stop();
            break;

            default: 
            // All other sounds go to SFX Track
            soundEffects.Stop();
            break;
        }
    }

    // public void FadeOut(string name)
    // {
    //     Sound s = Array.Find(sounds, sound => sound.name == name);
    //     if (s == null)
    //     {
    //         Debug.LogWarning("Sound: " + name + " not found!");
    //         return;
    //     } 

    //     s.source.volume -= Time.deltaTime * fadeSpeed;   
    // }
}

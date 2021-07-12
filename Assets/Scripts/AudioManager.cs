using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; 

    public float fadeSpeed = 1f;

    public static AudioManager instance;

    void OnClick()
    {
        Play("select");
    }

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene());
        Play("menu");
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

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {

            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
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

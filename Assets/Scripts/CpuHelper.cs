using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CpuHelper : MonoBehaviour
{
    public static CpuHelper instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return; //prevents other code from running before offing itself
        }

        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame

    public void PlayerVsCPU()
    {
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Select);
        FindObjectOfType<AudioManager>().StopPlaying(Sound.SoundType.Menu);
        FindObjectOfType<AudioManager>().Play(Sound.SoundType.Ready_VO);
    }
}

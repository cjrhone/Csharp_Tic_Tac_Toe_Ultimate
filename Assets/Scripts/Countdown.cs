using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class Countdown : MonoBehaviour
{
    private float timeLeft = 5.0f;
    public Text timerText;
    public Explode cube;
    bool cubeExploded;
    
    void Start()
    {
        timerText.text = timeLeft.ToString("F2");
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0.0f){
          timeLeft = 0;
          //TODO: Here we would add an "event" that brodcasts that the timer's up
        //   Debug.Log("Times up!");

        // if(!cubeExploded){
        //     cubeExploded = true;
        //     cube.CreateSmallCubes();
        // }
    }

        timerText.text = timeLeft.ToString("F2");
        
    }

    // public string FormatTime(Text timerText)
    // {
    //     int intTime = int.Parse(timerText.text);
    //     int minutes = intTime / 60;
    //     int seconds = intTime % 60;
    //     int fraction = timerText * 1000;
    //     fraction = fraction % 1000;
    //     string timeText = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds,fraction);
    //     return timeText;
    // }

    public void ResetTimer()
    {
        timeLeft = 5.0f;
        // cubeExploded = false;
    }
}

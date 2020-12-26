using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float timeLeft = 5.0f;
    public Text timerText;
    public GameObject cube;

    void Start()
    {
        timerText.text = timeLeft.ToString("F2");
    }

    
    void Update()
    {
        if (timeLeft <= 0)
        {
            timeLeft = 5.0f;
        }

        timeLeft -= Time.deltaTime;
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
    }
}

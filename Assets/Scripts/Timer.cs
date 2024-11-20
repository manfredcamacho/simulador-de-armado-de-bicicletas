using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI timerText;
    private bool timerRunning = false;
    private int hours;
    private int minutes;
    private int seconds;

    void Update()
    {
        if (timerRunning)
        {
            timer += Time.deltaTime;

            hours = Mathf.FloorToInt(timer / 3600);
            minutes = Mathf.FloorToInt(((timer / 60) % 60));
            seconds = Mathf.FloorToInt(timer % 60);

            timerText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }


    }

    public void startTimer()
    {
        timerRunning = true;
    }

    public void stopTimer()
    {
        timerRunning = false;
    }

    public int[] getLastTime()
    {
        return StaticData.lastTime;
    }

    public void saveTime()
    {
        int[] lastTime = { hours, minutes, seconds };
        StaticData.lastTime = lastTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 3540.0f;
    public TextMeshProUGUI timerText;
    void Update()
    {
        timer += Time.deltaTime;

        int hours = Mathf.FloorToInt(timer / 3600);
        int minutes = Mathf.FloorToInt(((timer / 60) % 60));
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");


    }
}

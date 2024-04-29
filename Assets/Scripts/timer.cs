using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float time;
    public bool timerOn = false;

    public TextMeshProUGUI timeText;

    private int minutes = 0;
    private int seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            time += Time.deltaTime;
            updateTimer(time);
        }

        seconds = (int)(time % 60);
        minutes = (int)(time / 60);
    }

    void updateTimer(float currentTime)
    {
        timeText.text = "Time: " + string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
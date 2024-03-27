using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Global variables
    public float timeRemaining;
    public bool isTimeRunning = false;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        isTimeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayTime();
        if (isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else if (timeRemaining <= 0)
            {
                isTimeRunning = false;
                timeRemaining = 0;
            }
        }
    }
    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour
{
    public Text timeText;
    public static DateTime currentTime;

    private float timeScale = 60f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = new DateTime(2020, 12, 5, 6, 0, 0);
        timeText.text = string.Format("{0:D2} : {1:D2}", currentTime.Hour, currentTime.Minute);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    void UpdateTime()
    {
        var displayingMinute = int.Parse(timeText.text.Substring(timeText.text.Length - 2));
        if (currentTime.Minute - displayingMinute >= 10 || currentTime.Minute - displayingMinute == -50)
        {
            timeText.text = string.Format("{0:D2} : {1:D2}", currentTime.Hour, currentTime.Minute);
        }
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeScale);
        // Debug.Log(currentTime.Hour + " : " + currentTime.Minute);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float time;
    private float minutes;
    private float seconds;
    private bool isTimerRunning = false;
    private long millisecond;
    private int test;

    private string timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimerRunning)
        {
            time += Time.deltaTime;
            minutes = Mathf.Floor(time / 60);
            seconds = time % 60;
            millisecond = Convert.ToInt64(seconds * 1000);
            test = Convert.ToInt32(time * 1000);
            timer = string.Format("{0:00} : {1:00}", minutes, seconds);
            Debug.Log(millisecond);
            Debug.Log(test);
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        PlayerPrefs.SetInt("TimeToUpdate", PlayerPrefs.GetInt("TimeToUpdate", 0) + test);
        Debug.Log(PlayerPrefs.GetInt("TimeToUpdate"));
        time = 0;
    }
}

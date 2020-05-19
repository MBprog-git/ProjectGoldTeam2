using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float time;
    private float minutes;
    private float seconds;
    private bool isTimerRunning = false;

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

            timer = string.Format("{0:00} : {1:00}", minutes, seconds);
            Debug.Log(time);
            Debug.Log(timer);
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        PlayerPrefs.SetFloat("TimeToUpdate", PlayerPrefs.GetFloat("TimeToUpdate",0) + time);
        time = 0;
    }
}

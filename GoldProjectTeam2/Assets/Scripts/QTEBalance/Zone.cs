using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Zone : MonoBehaviour
{
    public Camera cam;
    public Image outSideZone;
    public GameObject heart;

    public float zoneSpeed = 1.0f;
    public float zoneLimite = 5.0f;
    public float rangeToRebounce = 300.0f;
    public float timeOutSideToDie = 5.0f;

    private bool isInZone = false;
    private float currentPosition;

    public bool isRestarting = false;

    private int randomNumber;

    private float timeOutSideZone;
    private int timeOutSideZoneSecond;
    private Color tempColor;

    PlayOneSound sound;
    private AudioSource source;
    
    Rigidbody2D rb;

    void Awake()
    {
        sound = GetComponent<PlayOneSound>();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        cam.orthographic = true;
        tempColor = outSideZone.color;
    }


    void Update()
    {
        currentPosition = transform.localPosition.x;
        if(currentPosition >= zoneLimite && currentPosition >= zoneLimite - 10)
        {
            rb.velocity = new Vector2(-zoneSpeed, 0);
        }
        else if(currentPosition <= -zoneLimite && currentPosition <= -zoneLimite + 10)
        {
            rb.velocity = new Vector2(zoneSpeed, 0);
        }

        if(randomNumber < 0 && currentPosition >= -zoneLimite + rangeToRebounce)
        {
            rb.velocity = new Vector2(-zoneSpeed, 0);
        }
        else if(randomNumber > -1 && currentPosition <= zoneLimite - rangeToRebounce)
        {
            rb.velocity = new Vector2(zoneSpeed, 0);
        }

        if (!isInZone)
        {
            timeOutSideZone += Time.deltaTime;
            timeOutSideZoneSecond = Convert.ToInt32(timeOutSideZone % 60);
            cam.orthographicSize -= 0.005f;
            tempColor.a += 0.005f;
            outSideZone.color = tempColor;
            sound.PlaySound();
            source.volume += 0.01f;
            if (timeOutSideZoneSecond >= timeOutSideToDie)
            {
                GameManager.instance.MyLoadScene("LoseScene");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Balance")
        {
            timeOutSideZone = 0;
            timeOutSideZoneSecond = 0;
            cam.orthographicSize = 4;
            tempColor.a = 0;
            outSideZone.color = tempColor;
            sound.StopSound();
            source.volume = 0.5f;
            isInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag =="Balance")
        {
            if(!GameManager.instance.mister.GetComponent<Mister>().isAheadOfPlayer)
            {
                isInZone = false;
            }
        }
    }

    public void StartMovementZone()
    {
        if(isRestarting)
        {
            InvokeRepeating("GetRandomNumber", 0.0f, 4.0f);
            isRestarting = false;
        }
    }

    public void GetRandomNumber()
    {
        randomNumber = Random.Range(-1, 1);
    }

    public void ResetPosition()
    {
        if(isRestarting)
        {
        transform.localPosition = new Vector2(0, 0);
        heart.transform.localPosition = new Vector2(0, 0);

        }
    }
}

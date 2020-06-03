using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float zoneSpeed = 1.0f;
    public float zoneLimite = 5.0f;

    private bool isInZone = false;
    private float currentPosition;

    public bool isRestarting = false;
    public bool goToRight;
    public bool goToLeft;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //rb.velocity = new Vector2(zoneSpeed, 0);
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Balance")
        {
            isInZone = true;
        }
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Balance")
    //    {
    //        isInZone = true;
    //    }
    //}

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag =="Balance")
        {
            if(!GameManager.instance.mister.GetComponent<Mister>().isAheadOfPlayer)
            {
                isInZone = false;
                GameManager.instance.MyLoadScene("LoseScene");
            }
        }
    }

    public void StartMovementZone()
    {
        if(isRestarting)
        {
          rb.velocity = new Vector2(zoneSpeed, 0);
            isRestarting = false;
        }
    }
}

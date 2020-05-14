using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float zoneSpeed = 1.0f;
    public float zoneLimite = 5.0f;

    private bool isInZone = false;
    private float currentPosition;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    void Start()
    {
        rb.velocity = new Vector2(zoneSpeed, 0);
    }

    void Update()
    {
        currentPosition = transform.localPosition.x;
        if(currentPosition >= zoneLimite)
        {
            rb.velocity = new Vector2(-zoneSpeed, 0);
        }
        else if(currentPosition <= -zoneLimite)
        {
            rb.velocity = new Vector2(zoneSpeed, 0);
        }

        if(!isInZone)
        {
            //Debug.Log("Hors de la zone");
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
            isInZone = false;
            Debug.Log("exit");
        }
    }
}

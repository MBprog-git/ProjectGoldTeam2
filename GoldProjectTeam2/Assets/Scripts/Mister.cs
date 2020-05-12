using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mister : MonoBehaviour
{
    public GameObject player;
    public int speed = 15;
    public float halfwayDistance = 50.0f;
    public float almostInScreenDistance = 20.0f;

    private float distanceToPlayer;
    private bool halfway = false;
    private bool almostInScreen = false;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = new Vector2(speed, 0);
        Handheld.Vibrate();
    }

    void Update()
    {
        distanceToPlayer = player.transform.position.x - transform.position.x;
        if(distanceToPlayer <= halfwayDistance && halfway == false)
        {
            halfway = true;
            Debug.Log("halfway");
            Handheld.Vibrate();
        }
        else if (distanceToPlayer <= almostInScreenDistance && almostInScreen == false)
        {
            almostInScreen = true;
            Debug.Log("Almost in screen");
            Handheld.Vibrate();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Death");
        }
    }
}

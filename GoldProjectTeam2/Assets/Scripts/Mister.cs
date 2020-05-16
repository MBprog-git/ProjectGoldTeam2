using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mister : MonoBehaviour
{
    public GameObject player;
    public GameObject rythmQTE;
    public GameObject balanceQTE;
    public int speedBase = 15;
    public float speed;
    private float spawnDistanceToPlayer;
    private float halfwayDistance;
    public float almostInScreenDistance = 20.0f;
    public float distanceForRythmeQTE = 15.0f;
    public float distanceForBalanceQTE = 5.0f;

    public float distanceToPlayer;
    public bool halfway = false;
    public bool almostInScreen = false;

    private float randomDistance;
    private bool isRandomDistanceVibrationActivated = false;

    Rigidbody2D rb;

    void Awake()
    {
        speed = speedBase;
        rb = GetComponent<Rigidbody2D>();
        spawnDistanceToPlayer = player.transform.position.x;
    }

    void Start()
    {
        rb.velocity = new Vector2(speed, 0);
        Handheld.Vibrate();
        randomDistance = Random.Range(10, 100) - 5;
        halfwayDistance = spawnDistanceToPlayer / 2 * -1;
        Debug.Log(randomDistance);
    }

    void Update()
    {
        FunctionDistance();
    }

    void FunctionDistance()
    {
        distanceToPlayer = (player.transform.position.x + transform.position.x) * -1;
        if (distanceToPlayer <= halfwayDistance && halfway == false)
        {
            halfway = true;
            Debug.Log("halfway");
            Handheld.Vibrate();
        }

        if (distanceToPlayer <= almostInScreenDistance && almostInScreen == false)
        {
            almostInScreen = true;
            Debug.Log("Almost in screen");
            Handheld.Vibrate();
        }

        if (!isRandomDistanceVibrationActivated)
        {
            if (transform.position.x >= randomDistance)
            {
                Handheld.Vibrate();
                isRandomDistanceVibrationActivated = true;
            }
        }

        if (distanceToPlayer <= distanceForRythmeQTE && distanceToPlayer >= distanceForBalanceQTE && GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            rythmQTE.SetActive(true);
            balanceQTE.SetActive(false);
            return;
        }

        if (distanceToPlayer <= distanceForBalanceQTE && distanceToPlayer >= -distanceForBalanceQTE && GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            rythmQTE.SetActive(false);
            balanceQTE.SetActive(true);
            return;
        }

        if (distanceToPlayer <= -distanceForBalanceQTE)
        {
            rythmQTE.SetActive(false);
            balanceQTE.SetActive(false);
            Debug.Log("esquiver");
            return;
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && !GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            rythmQTE.SetActive(false);
            balanceQTE.SetActive(false);
            Debug.Log("Death");
        }
    }
}

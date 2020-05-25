using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mister : MonoBehaviour
{
    private GameObject player;
    private GameObject rythmQTE;
    private GameObject balanceQTE;

    public bool isRythmQTEActif = false;
    public bool isBalanceQTEActif = false;

    public int speedBase = 15;
    public float speed;
    private float spawnDistanceToPlayer;
    public float halfwayDistance= 50.0f;
    public float almostInScreenDistance = 20.0f;
    public float distanceForRythmeQTE = 15.0f;
    public float distanceForBalanceQTE = 5.0f;

    public float distanceToPlayer;
    public bool halfway = false;
    public bool almostInScreen = false;

    private float randomDistance;
    private bool isRandomDistanceVibrationActivated = false;

    Rigidbody rb;

    void Awake()
    {
        speed = speedBase;
        rb = GetComponent<Rigidbody>();

        player = GameManager.instance.Player;
        rythmQTE = GameManager.instance.QTERythme;
        balanceQTE = GameManager.instance.QTEBalance;
        spawnDistanceToPlayer = player.transform.position.x;
    }

    void Start()
    {
        rb.velocity = new Vector2(speed, 0);
        Handheld.Vibrate();
        randomDistance = Random.Range(10, 100) - 5;
        //halfwayDistance = spawnDistanceToPlayer / 2 * -1; 
    }

    void Update()
    {
        FunctionDistance();
    }

    void FunctionDistance()
    {
        distanceToPlayer = (player.transform.position.x - transform.position.x) ;

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
            isRythmQTEActif = true;
            isBalanceQTEActif = false;
            return;
        }

        if (distanceToPlayer <= distanceForBalanceQTE && distanceToPlayer >= -distanceForBalanceQTE && GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            rythmQTE.SetActive(false);
            balanceQTE.SetActive(true);
            isRythmQTEActif = false;
            isBalanceQTEActif = true;
            return;
        }

        if (distanceToPlayer <= -distanceForBalanceQTE)
        {
            rythmQTE.SetActive(false);
            balanceQTE.SetActive(false);
            isRythmQTEActif = false;
            isBalanceQTEActif = false;
            Debug.Log("esquiver");
            return;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && !GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            rythmQTE.SetActive(false);
            balanceQTE.SetActive(false);
            isRythmQTEActif = false;
            isBalanceQTEActif = false;
            Debug.Log("Death");
        }
    }
}

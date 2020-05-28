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

    public float speedBase = 15.0f  ;
    public float speed;
    private float spawnDistanceToPlayer;
    public float halfwayDistance= 50.0f;
    public float almostInScreenDistance = 20.0f;
    public float distanceForRythmeQTE = 15.0f;
    public float distanceForBalanceQTE = 5.0f;
    public float distanceToPlayer;
    public float distanceToTeleportCompareToPlayerPosition = 100.0f;
    public bool halfway = false;
    public bool almostInScreen = false;

    private float randomDistance;
    private bool isRandomDistanceVibrationActivated = false;

    public float distanceTeleportationTrigger = 25.0f;
    private bool isAheadOfPlayer = false;
    public float PlusPlayer;
    public float MultiplierSlow;
    public float MultiplierSlowHide;
    Rigidbody rb;

    void Awake()
    {
        speedBase = GameManager.instance.Player.GetComponent<PlayerMovement>().speedBase + PlusPlayer;
        speed = speedBase;
        rb = GetComponent<Rigidbody>();

        player = GameManager.instance.Player;
        rythmQTE = GameManager.instance.QTERythme;
        balanceQTE = GameManager.instance.QTEBalance;
        spawnDistanceToPlayer = player.transform.position.x;
    }

    void Start()
    {
       // rb.velocity = new Vector2(speed, 0);
        Handheld.Vibrate();
        randomDistance = Random.Range(10, 100) - 5;
        halfwayDistance = player.GetComponent<PlayerMovement>().distanceInOrderToSpawnMan / 2;
    }

    void Update()
    {


        if (!GameManager.instance.IsMoving && !GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            speed = speedBase * MultiplierSlow;

        }
        else if (!GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            speed = speedBase;
        }
        transform.Translate(1 * Time.deltaTime * speed, 0, 0);
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

        if (distanceToPlayer <= distanceForBalanceQTE && distanceToPlayer >= -distanceForRythmeQTE && GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            balanceQTE.SetActive(true);
            isBalanceQTEActif = true;
            rythmQTE.SetActive(false);
            GameManager.instance.QTERythme.GetComponent<SpawnNote>().ClearList();
            isRythmQTEActif = false;
            return;
        }

        //esquiver
        if (distanceToPlayer <= -distanceForBalanceQTE - distanceForRythmeQTE)
        {
            rythmQTE.SetActive(false);
            GameManager.instance.QTERythme.GetComponent<SpawnNote>().ClearList();
            balanceQTE.SetActive(false);
            isRythmQTEActif = false;
            isBalanceQTEActif = false;
            isAheadOfPlayer = true;
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
            
            GameManager.instance.MyLoadScene("LoseScene");
        }

        if(col.gameObject.tag == "Hideout" && GameManager.instance.Player.GetComponent<PlayerMovement>().Hidden)
        {
            speed = speedBase * MultiplierSlowHide;

        }

        if (col.gameObject.tag == "TP")
        {
            transform.position = new Vector2(player.transform.position.x - distanceToTeleportCompareToPlayerPosition,0);
        }
    }
}

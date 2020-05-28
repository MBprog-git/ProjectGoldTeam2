using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ManagerButtonPlayer))]
public class PlayerMovement : MonoBehaviour
{

    public float speedBase = 5.0f;
    public float speed;
    [SerializeField]
    private float smoothStopMove = 2.0f;

    public bool Hidden;
    public bool Canhide = true;

    public float distanceInOrderToSpawnMan = 100.0f;
    public GameObject shadowMan;
    public GameObject PlayerSp;
    private bool shadowManIsRelease = false;

    private Rigidbody rb;
    Animator animator;
    SpriteRenderer sp;
    [HideInInspector] public ManagerButtonPlayer manageButton;

    GameObject LastCach;

    PlayOneSound Audio;
    AudioSource source;

    public Camera cam;
    //public float camViewPositionX = -5;
    //public float camViewPositionY = 0;
    //private Vector2 camViewPosition;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        Audio = GetComponent<PlayOneSound>();
        animator = PlayerSp.GetComponent<Animator>();
        sp = PlayerSp.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        manageButton = GetComponent<ManagerButtonPlayer>();
        speed = speedBase;

        cam.orthographic = true;
        //camViewPosition = new Vector2(camViewPositionX, camViewPositionY);
    }

    public void Update()
    {

        if (Time.timeScale == 0)
        {
            manageButton.goLeft = false;
            manageButton.goRight = false;
        }
        if (!Hidden)
        {
            if (manageButton.goRight && !manageButton.goLeft)
            {
                /* if (rb.velocity.x < speed)
                 {
                     rb.AddForce(new Vector3(speed * Time.timeScale, 0, 0), ForceMode.Force);
                 }
                 else
                 {
                     rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
                 }*/
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);
                sp.flipX = false;
            }
            else if (manageButton.goLeft && !manageButton.goRight)
            {
                /* if (rb.velocity.x > -speed)
                 {
                     rb.AddForce(new Vector3(-speed * Time.timeScale, 0, 0), ForceMode.Force);
                 }
                 else
                 {
                     rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
                 }*/


                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);

                sp.flipX = true;
            }
        }
        if (manageButton.goLeft || manageButton.goRight)
        {
            GameManager.instance.IsMoving = true;
            animator.SetBool("Is_Walking", true);
            if (!source.isPlaying)
            {
                Audio.PlaySound();

            }
            if (Hidden && !GameManager.instance.mister.GetComponent<Mister>().isBalanceQTEActif && !GameManager.instance.mister.GetComponent<Mister>().isRythmQTEActif)
            {
                HideMe(LastCach);
            }
        }
        else
        {
            GameManager.instance.IsMoving = false;
            animator.SetBool("Is_Walking", false);
            Audio.StopSound();
        }


        if (transform.position.x >= distanceInOrderToSpawnMan && !shadowManIsRelease)
        {
            SpawnMan();
        }

    }

    public void HideMe(GameObject Cachette)
    {
        //  Debug.Log(Vector3.Distance(transform.position, Cachette.transform.position));
        if ((Canhide && Vector3.Distance(transform.position, Cachette.transform.position) < 5) || Hidden)
        {

            Hidden = !Hidden;
            cam.orthographicSize = 5.0f;
            //cam.rect = new Rect(0, camViewPositionY, cam.rect.height, cam.rect.width);
            if (Hidden)
            {
                //anim caché +QTE;
                transform.position = new Vector3(Cachette.transform.position.x, transform.position.y, transform.position.z);
                //  Cachette.transform.position = new Vector3(Cachette.transform.position.x, Cachette.transform.position.y, 0);
                rb.velocity = Vector3.zero;
                GameManager.instance.HideUi.SetActive(true);
                LastCach = Cachette;
                PlayerSp.SetActive(false);
                cam.orthographicSize = 4.0f;
                //cam.rect = new Rect(camViewPositionX, camViewPositionY, cam.rect.height, cam.rect.width);

            }
            else if (GameManager.instance.mister.GetComponent<Mister>().isBalanceQTEActif || GameManager.instance.mister.GetComponent<Mister>().isRythmQTEActif)
            {
                Hidden = true;
            }
            else
            {

                // Cachette.transform.position = new Vector3(Cachette.transform.position.x, Cachette.transform.position.y, 2);
                GameManager.instance.HideUi.SetActive(false);
                PlayerSp.SetActive(true);

            }

        }
    }

    public void SpawnMan()
    {
        GameObject badGuy = Instantiate(shadowMan);
        GameManager.instance.mister = badGuy;
        badGuy.transform.position = new Vector3(0, 0, transform.position.z);
        shadowManIsRelease = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            if (GameManager.instance.Journal.GetComponent<JournalMB>().Dessin[2] == null)
            {

                Debug.Log("BAD END");
                GameManager.instance.Player.GetComponent<Score>().StopTimerLose();
                GameManager.instance.MyLoadScene("LoseScene2");
            }
            else
            {
                GameManager.instance.Player.GetComponent<Score>().StopTimer();
                GameManager.instance.Player.GetComponent<GPGSLeaderboard>().UpdateLeaderboard();
                GameManager.instance.MyLoadScene("VictoryScene");
            }
        }
    }
}

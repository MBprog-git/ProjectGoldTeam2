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

    private void Start()
    {
        animator = PlayerSp.GetComponent<Animator>();
        sp = PlayerSp.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        manageButton = GetComponent<ManagerButtonPlayer>();
        speed = speedBase;
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
                if (rb.velocity.x < speed)
                {
                    rb.AddForce(new Vector3(speed * Time.timeScale, 0, 0), ForceMode.Force);
                }
                else
                {
                    rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
                }
                sp.flipX = false;
            }
            else if (manageButton.goLeft && !manageButton.goRight)
            {
                if (rb.velocity.x > -speed)
                {
                    rb.AddForce(new Vector3(-speed * Time.timeScale, 0, 0), ForceMode.Force);
                }
                else
                {
                    rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
                }
               sp.flipX = true;
            }
        }
            if(manageButton.goLeft || manageButton.goRight)
            {
                GameManager.instance.IsMoving = true;
                animator.SetBool("Is_Walking", true);
            if (Hidden)
            {
                HideMe(LastCach);
            }
            }
            else
            {
                GameManager.instance.IsMoving = false;
                animator.SetBool("Is_Walking", false);

            }


            if (transform.position.x >= distanceInOrderToSpawnMan && !shadowManIsRelease)
            {
                SpawnMan();
            }
        
    }

    public void HideMe(GameObject Cachette)
    {
        if ((Canhide  && Vector3.Distance(transform.position, Cachette.transform.position)<2) || Hidden) {

            Hidden = !Hidden;
            if (Hidden)
            {
                //anim caché +QTE;
                transform.position = Cachette.transform.position;
                //  Cachette.transform.position = new Vector3(Cachette.transform.position.x, Cachette.transform.position.y, 0);
                rb.velocity = Vector3.zero;
                GameManager.instance.HideUi.SetActive(true);
                LastCach = Cachette;
                PlayerSp.SetActive(false);
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
       GameManager.instance.mister =badGuy;
        badGuy.transform.position = new Vector3(0, 0, transform.position.z);
        shadowManIsRelease = true;
    }
}

﻿using System.Collections;
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
    private bool shadowManIsRelease = false;

    private Rigidbody rb;
    [HideInInspector] public ManagerButtonPlayer manageButton;

    private void Start()
    {
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
            }
            if (transform.position.x >= distanceInOrderToSpawnMan && !shadowManIsRelease)
            {
                SpawnMan();
            }
        }
    }

    public void HideMe(GameObject Cachette)
    {
        if ((Canhide || Hidden) && Vector3.Distance(transform.position, Cachette.transform.position)<2) {

            Hidden = !Hidden;
            if (Hidden)
            {
                //anim caché +QTE;
                transform.position = Cachette.transform.position;
                Cachette.transform.position = new Vector3(Cachette.transform.position.x, Cachette.transform.position.y, 0);
                rb.velocity = Vector3.zero;
            }
            else
            {
                Cachette.transform.position = new Vector3(Cachette.transform.position.x, Cachette.transform.position.y, 2);
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

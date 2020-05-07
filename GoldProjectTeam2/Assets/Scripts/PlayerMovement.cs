using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ManagerButtonPlayer))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float smoothStopMove = 2.0f;

    private Rigidbody rb;
    private ManagerButtonPlayer manageButton;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        manageButton = GetComponent<ManagerButtonPlayer>();
    }

    public void Update()
    {

        if (Time.timeScale == 0)
        {
            manageButton.goLeft = false;
            manageButton.goRight = false;
        }

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
    }

}

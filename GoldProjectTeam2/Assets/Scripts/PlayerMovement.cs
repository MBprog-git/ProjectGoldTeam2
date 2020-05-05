using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float smoothStopMove = 2.0f;

    private Rigidbody rb;
    private bool goLeft = false;
    private bool goRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (goRight && !goLeft)
        {
            if (rb.velocity.x < speed)
            {
                rb.AddForce(new Vector3 (speed,0,0), ForceMode.Force);
            }
            else
            {
                rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            }
        }else if (goLeft && !goRight)
        {
            if (rb.velocity.x > -speed)
            {
                rb.AddForce(new Vector3(-speed, 0, 0), ForceMode.Force);
            }
            else
            {
                rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            }
        }
    }

    public void ButtonDownLeft()
    {
        goLeft = true;
    }

    public void ButtonUpLeft()
    {
        goLeft = false;
        if (rb.velocity.x < -smoothStopMove)
        {
            rb.velocity = new Vector3(-smoothStopMove, rb.velocity.y, rb.velocity.z);
        }
    }

    public void ButtonDownRight()
    {
        goRight = true;
    }

    public void ButtonUpRight()
    {
        goRight = false;
        if (rb.velocity.x > smoothStopMove)
        {
            rb.velocity = new Vector3(smoothStopMove, rb.velocity.y, rb.velocity.z);
        }
    }
}

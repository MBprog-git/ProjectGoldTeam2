using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = 30.0f;

    private Vector3 move = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        move *= speed;

        if(Input.GetButtonDown("Jump"))
        {
            move.y = jumpForce;
        }

        move.y -= gravity * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
    }
}

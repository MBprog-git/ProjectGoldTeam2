using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GommeTestMB : MonoBehaviour
{
    Vector3 OldPos;
    public GameObject GOMME;

    void Update()
    {
        Vector3 mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (Input.GetKey(KeyCode.Mouse0) && mousePos != OldPos)
        {
            Instantiate(GOMME, mousePos, transform.rotation);
            OldPos = mousePos;
        }

        /*// Track a single touch as a direction control.
        if (Input.touchCount > 0 )
        {
            Touch touch = Input.GetTouch(0);


            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    Debug.Log("Touch");
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    Instantiate(GOMME, touch.position, transform.rotation);
                    Debug.Log("Moved");
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends

                    break;
            }
        }*/
    } }


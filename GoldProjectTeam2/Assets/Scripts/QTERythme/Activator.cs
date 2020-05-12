using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    private bool active = false;
    private GameObject note;

    private bool isLongNoteInActivator = false;
    private bool failLongNote = false;

    private float pressedTime;

    public float neededTimeToPressForLongNote = 1.0f;

    SpriteRenderer sr;
    Color oldColor;

    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        oldColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // finger was just put down
                    sr.color = new Color(0, 0, 0);
                    if (active && note.tag == "Note")
                    {
                        Destroy(note);
                        active = false;
                        return;
                    }

                    break;

                case TouchPhase.Ended:
                    // finger was just removed
                    sr.color = oldColor;
                    if (isLongNoteInActivator && note.tag == "LongNote")
                    {
                        isLongNoteInActivator = false;
                        failLongNote = true;
                    }

                    break;

                case TouchPhase.Moved:
                    // finger was already down and has moved

                    break;

                case TouchPhase.Stationary:
                    // finger was already down and hasnt moved
                    sr.color = new Color(0, 0, 0);
                    if (isLongNoteInActivator && note.tag == "LongNote")
                    {
                        pressedTime += Time.deltaTime;
                    }

                    break;

                case TouchPhase.Canceled:
                    // touch was canceled by the system
                    break;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note" || col.gameObject.tag == "LongNote")
        {
            Debug.Log(pressedTime);
            note = col.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D stay)
    {
        if(stay.gameObject.tag == "LongNote")
        {
            isLongNoteInActivator = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
        isLongNoteInActivator = false;
        if (col.gameObject.tag == "LongNote" && failLongNote == true)
        {
            Debug.Log(pressedTime);
            if(pressedTime >= neededTimeToPressForLongNote)
            {
                Destroy(col.gameObject);
                pressedTime = 0.0f;
            }
        }
    }
}

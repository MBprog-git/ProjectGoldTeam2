using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activator : MonoBehaviour
{
    private bool active = false;
    private GameObject note;
    private bool isLongNoteInActivator = false;
    private float pressedTime;

    public float neededTimeToPressForLongNote = 1.0f;

    Image image;

    Color oldColor;

    // Start is called before the first frame update
    void Awake()
    {
        //sr = GetComponent<SpriteRenderer>();
        //oldColor = sr.color;
        image = GetComponent<Image>();
        oldColor = image.color;
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
                    image.color = new Color(0, 0, 0);
                    if (active && note.tag == "Note")
                    {
                        Destroy(note);
                        active = false;
                        return;
                    }
                    break;
                case TouchPhase.Ended:
                    // finger was just removed
                    image.color = oldColor;

                    break;
                case TouchPhase.Moved:
                    // finger was already down and has moved
                    break;
                case TouchPhase.Stationary:
                    // finger was already down and hasnt moved
                    image.color = new Color(0, 0, 0);
                    if (isLongNoteInActivator && note.tag == "LongNote")
                    {
                        pressedTime += Time.deltaTime;
                    }
                    break;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        active = true;
        if (col.gameObject.tag == "Note" || col.gameObject.tag == "LongNote")
        {
            note = col.gameObject;
            if(col.gameObject.tag =="LongNote")
            {
                isLongNoteInActivator = true;
            }
        }
    }

    //void OnTriggerStay2D(Collider2D stay)
    //{
    //    if (stay.gameObject.tag == "LongNote")
    //    {
    //        isLongNoteInActivator = true;
    //    }
    //}

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
        isLongNoteInActivator = false;
        if (col.gameObject.tag == "LongNote")
        {
            if(pressedTime >= neededTimeToPressForLongNote)
            {
                Destroy(col.gameObject);
                pressedTime = 0.0f;
                return;
            }
            GameManager.instance.MyLoadScene("LoseScene");
        }
    }
}

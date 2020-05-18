using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;

    private Vector2 fingerPosition;

    public float minimalSwipeDistance;



    void Update()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        startPosition = touch.position;
                        break;
                    case TouchPhase.Ended:
                        endPosition = touch.position;

                    if (Vector2.Distance(startPosition, endPosition) > minimalSwipeDistance && GameManager.instance.Journal.GetComponent<JournalMB>().activated)
                    {
                        AnalyzeSwipeDirection(startPosition, endPosition);
                    }
                    else
                    {
                        Debug.Log("swipe trop court");
                    }


                    break;
                }
            
        }
    }

    private void AnalyzeSwipeDirection(Vector2 start, Vector2 end)
    {
        Vector2 dragVectorDirection = (end - start).normalized;
        float positiveX = Mathf.Abs(dragVectorDirection.x);
        float positiveY = Mathf.Abs(dragVectorDirection.y);


        if (positiveX > positiveY)
        {
           if (dragVectorDirection.x > 0)
            {
                //gauche
                GameManager.instance.Journal.GetComponent<JournalMB>().PageV2(true);
                Debug.Log("Swipe gauche");
            }
            else
            {
                GameManager.instance.Journal.GetComponent<JournalMB>().PageV2(false);
                //droite
                Debug.Log("Swipe Droite");
            }
        }
        else
        {
            if (dragVectorDirection.y > 0)
            {
                //down?
                Debug.Log("Swipe down");
                GameManager.instance.Journal.GetComponent<JournalMB>().RemoveItems();
            }
            else
            {
                //up?
                Debug.Log("Swipe up");
            }
               
        }

    }

}

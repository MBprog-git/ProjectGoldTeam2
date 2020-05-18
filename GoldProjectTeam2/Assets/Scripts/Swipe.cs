using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;

    private Vector2 fingerPosition;

    public float minimalSwipeDistance = 150;

    public GameObject mask;
    private bool isOnNoteBook = true;

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
                        AnalyzeSwipeDistance(startPosition, endPosition);
                    if (GameManager.instance.Journal.GetComponent<JournalMB>().activated)
                    {

                    AnalyzeSwipeDirection(startPosition, endPosition);
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
            }
            else
            {
                GameManager.instance.Journal.GetComponent<JournalMB>().PageV2(false);
                //droite
            }
        }
        else
        {
            if (dragVectorDirection.y > 0)
            {
                //down?
                GameManager.instance.Journal.GetComponent<JournalMB>().RemoveItems();
            }
            else
            {
                //up?
            }
               
        }

    }
    private void AnalyzeSwipeDistance(Vector2 start, Vector2 end)
    {
        // Distance
        if (Vector2.Distance(start, end) > minimalSwipeDistance)
        {
            Handheld.Vibrate();
        }

    }
}

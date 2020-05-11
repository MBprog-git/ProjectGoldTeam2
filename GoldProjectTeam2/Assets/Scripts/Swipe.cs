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
                        break;
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

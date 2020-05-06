using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;

    public float minimalSwipeDistance = 150;
    // Start is called before the first frame update
    void Start()
    {

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
            Debug.Log("swipe");
        }

    }
}
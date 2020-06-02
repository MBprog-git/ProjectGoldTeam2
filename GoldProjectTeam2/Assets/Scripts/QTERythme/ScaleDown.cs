using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDown : MonoBehaviour
{
    public GameObject center;
    public float scaleTime = 0.001f;

    private Vector2 centerPosition;
    private Vector2 newScale;
    // Start is called before the first frame update
    void Start()
    {
        centerPosition = center.transform.position;
        newScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        newScale.y = newScale.y - scaleTime;
        newScale.x = newScale.x - scaleTime;

        transform.localScale = newScale;
        transform.localPosition = centerPosition;
    }
}

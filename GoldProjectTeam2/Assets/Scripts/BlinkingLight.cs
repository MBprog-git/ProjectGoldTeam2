using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    public GameObject firstLight;
    public GameObject secondLight;
    public float interval;
    void Start()
    {
        InvokeRepeating("FlashLabel", 0, interval);
    }

    void FlashLabel()
    {
        if (firstLight)
        {
            firstLight.SetActive(false);
            secondLight.SetActive(false);
        }
        else
        {
            firstLight.SetActive(true);
            secondLight.SetActive(true);
        }
    }
}

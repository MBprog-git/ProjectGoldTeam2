using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJScript : MonoBehaviour
{
    public bool GoRight;
    public float HyperSpeedo;
    public float TimerDisappear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GoRight)
        {
            transform.Translate(1 * HyperSpeedo * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-1 * HyperSpeedo * Time.deltaTime, 0, 0);

        }

        TimerDisappear -= Time.deltaTime;
        if (TimerDisappear < 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}

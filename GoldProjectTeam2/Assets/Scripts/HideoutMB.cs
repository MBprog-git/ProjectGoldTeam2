using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideoutMB : MonoBehaviour
{
    public GameObject CantFeedback;
   public float timerBase;
    float timer;
    PlayMultipleSound Audio;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerBase;
        Audio = GetComponent<PlayMultipleSound>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !GameManager.instance.Player.GetComponent<PlayerMovement>().Canhide)
        {
            CantFeedback.SetActive(true);

        }
        else
        {
            CantFeedback.SetActive(false);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && GameManager.instance.CorbacSound)
        {
            if (timer < 0 )
            {
                int a = Random.Range(0, 2);
                if (a == 0)
                {
                Audio.PlaySound(TYPE_AUDIO.SfxCorbeau1);

                }
                if (a == 1)
                {
                Audio.PlaySound(TYPE_AUDIO.SfxCorbeau2);

                }

                    timer = timerBase;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        
        }

        }

}

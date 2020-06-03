using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activation : MonoBehaviour
{
    public GameObject smallerEmptyHeart;
    public GameObject biggerEmptyHeart;
    public GameObject twentyPercent;
    public GameObject thirtyPercent;

    Image image;
    Color oldColor;
    PlayMultipleSound sound;
    private int numberOfFail = 0;

    private GameObject firstHeart;
    private GameObject actualHeart;
    private GameObject rythm;

    private Vector3 limiteToPassQTE = new Vector3(1, 1, 1);
    private Vector3 limiteToFailQTE = new Vector3(0.5f, 0.5f, 1);

    private bool isFirstSoundAlreadyPlay = false;

    void Awake()
    {
        sound = GetComponent<PlayMultipleSound>();
        rythm = gameObject;
        image = GetComponent<Image>();
        oldColor = image.color;
    }

    void Update()
    {
        if (transform.childCount <= 0)
        {
            GameObject emptyHeartSmall = Instantiate(smallerEmptyHeart, rythm.transform.localPosition, Quaternion.identity);
            emptyHeartSmall.transform.SetParent(rythm.transform);
            emptyHeartSmall.transform.localScale = new Vector3(15, 15, 1);
      
            GameObject emptyHeartBig = Instantiate(biggerEmptyHeart);
            emptyHeartBig.transform.SetParent(rythm.transform);
            emptyHeartBig.transform.localScale = new Vector3(18, 18, 1);
        }

        ChangeFirstHeart();
        //firstHeart = transform.GetChild(0).gameObject;
        //secondtHeart = transform.GetChild(1).gameObject;


        GetActualHeart();

        if(actualHeart.transform.localScale.x < limiteToFailQTE.x)
        {
            Destroy(actualHeart);
            numberOfFail++;
            GameManager.instance.Player.GetComponent<PlayerMovement>().FailQTE();
            ChangeFirstHeart();
            Debug.Log(numberOfFail);
        }

        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // finger was just put down
                    image.color = new Color(0, 0, 0);

                    if (actualHeart.transform.localScale.x <= limiteToPassQTE.x && actualHeart.transform.localScale.x >= limiteToFailQTE.x)
                    {
                        WhichSoundToPlay();
                        Destroy(actualHeart);
                    }

                    if (actualHeart.transform.localScale.x > limiteToPassQTE.x)
                    {
                        Destroy(actualHeart);
                        numberOfFail++;
                        GameManager.instance.Player.GetComponent<PlayerMovement>().FailQTE();
                        ChangeFirstHeart();
                        Debug.Log(numberOfFail);
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

                    break;
            }

        }
        OnFail();
    }

    private void ChangeFirstHeart()
    {
        firstHeart = transform.GetChild(0).gameObject;
    }

    private void GetActualHeart()
    {
        if(firstHeart)
        {
            actualHeart = firstHeart;
            return;
        }

        actualHeart = null;
    }

    private void OnFail()
    {
        switch(numberOfFail)
        {
            case 1:
                twentyPercent.SetActive(true);
                thirtyPercent.SetActive(false);
                break;
            case 2:
                twentyPercent.SetActive(false);
                thirtyPercent.SetActive(true);
                break;
            case 3:
                Debug.Log("GameOver");
                break;
        }
    }

    private void WhichSoundToPlay()
    {
        if(!isFirstSoundAlreadyPlay)
        {
            sound.PlaySound(TYPE_AUDIO.HeartBeatA);
            isFirstSoundAlreadyPlay = true;
        }
        else
        {
            sound.PlaySound(TYPE_AUDIO.HeartBeatB);
            isFirstSoundAlreadyPlay = false;
        }
    }

    public void ResetOnTransitionQTE()
    {
        GameManager.instance.Player.GetComponent<PlayerMovement>().ResetCamera();
        twentyPercent.SetActive(false);
        twentyPercent.SetActive(false);
    }
}
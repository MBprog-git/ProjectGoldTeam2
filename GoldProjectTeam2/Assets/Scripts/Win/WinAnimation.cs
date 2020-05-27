using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinAnimation : MonoBehaviour
{
    public float faddingTime = 0.01f;
    public Image startImage;
    public GameObject firstImage;
    public GameObject secondImage;
    public GameObject thirdImage;

    public GameObject goToPosition;

    private Image first;
    private Image second;
    private Image third;

    private Vector2 secondImageMove;

    PlayMultipleSound Audio;

    // Start is called before the first frame update
    void Start()
    {
        first = firstImage.GetComponent<Image>();
        second = secondImage.GetComponent<Image>();
        third = thirdImage.GetComponent<Image>();

        secondImageMove.x = secondImage.transform.localPosition.x;
        secondImageMove.y = secondImage.transform.localPosition.y;

        Audio = GetComponent<PlayMultipleSound>();
    }


    public void StartWinAnimation()
    {
        StartCoroutine(FadeImage());
    }

    IEnumerator FadeImage()
    {
        var tempColor = startImage.color;

        for (float i = 1; i >= 0; i-= faddingTime)
        {
            tempColor.a = i;
            startImage.color = tempColor;
            yield return null;
        }


        tempColor = first.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            first.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            first.color = tempColor;
            yield return null;
        }


        tempColor = second.color;
        Audio.PlaySound(TYPE_AUDIO.Running);
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            second.color = tempColor;
            yield return null;
        }
        for (float i = 1; secondImageMove.x <= goToPosition.transform.localPosition.x;)
        {
            secondImageMove.x += i;
            secondImage.transform.localPosition = secondImageMove;
            Debug.Log(secondImage.transform.localPosition);
            Debug.Log(goToPosition.transform.localPosition.x);
            Debug.Log(secondImageMove.x);
            yield return null;
        }
        secondImage.SetActive(false);


        thirdImage.SetActive(true);
        Audio.PlaySound(TYPE_AUDIO.SlamDoor);
        yield return new WaitForSeconds(2);
        for (float i = 1; i >= 0.1; i -= 0.005f)
        {
            thirdImage.transform.localScale = new Vector2(i, i);
            yield return null;
        }

    }
}

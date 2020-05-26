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

    private Image first;
    private Image second;
    private Image third;

    private Vector2 secondImageMove;

    // Start is called before the first frame update
    void Start()
    {
        first = firstImage.GetComponent<Image>();
        second = secondImage.GetComponent<Image>();
        third = thirdImage.GetComponent<Image>();

        secondImageMove.x = secondImage.transform.position.x;
        secondImageMove.y = secondImage.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            first.color = tempColor;
            yield return null;
        }


        tempColor = second.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            second.color = tempColor;
            yield return null;
        }

        for (int i =  0; secondImage.transform.position.x <= -1; i++)
        {
            secondImageMove.x += i;
            secondImage.transform.position = secondImageMove;
            yield return null;
        }

        secondImage.SetActive(false);
        //for (float i = 1; i >= 0; i -= faddingTime)
        //{
        //    tempColor.a = i;
        //    second.color = tempColor;
        //    yield return null;
        //}

        thirdImage.SetActive(true);
        yield return new WaitForSeconds(2);
        for (float i = 1; i >= 0.1; i -= 0.005f)
        {
            thirdImage.transform.localScale = new Vector2(i, i);
            yield return null;
        }

    }
}

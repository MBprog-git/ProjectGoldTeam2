using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinAnimation : MonoBehaviour
{
    public float faddingTime = 0.01f;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;

    public GameObject menu;

    Image firstImage;
    Image secondImage;
    Image thirdImage;
    Image fourthImage;

    // Start is called before the first frame update
    void Awake()
    {
        firstImage = first.GetComponent<Image>();
        secondImage = second.GetComponent<Image>();
        thirdImage = third.GetComponent<Image>();
        fourthImage = fourth.GetComponent<Image>();
    }

    void Start()
    {
        StartCoroutine(Animation());

    }


    IEnumerator Animation()
    {
        var tempColor = firstImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            firstImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            firstImage.color = tempColor;
            yield return null;
        }


        tempColor = secondImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            secondImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            secondImage.color = tempColor;
            yield return null;
        }


        tempColor = thirdImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            thirdImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            thirdImage.color = tempColor;
            yield return null;
        }


        tempColor = fourthImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            fourthImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        menu.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseAnimationSecond : MonoBehaviour
{
    public float faddingTime = 0.01f;
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;

    public GameObject menu;

    Image firstImage;
    Image secondImage;
    Image thirdImage;
    Image fourthImage;
    Image fifthImage;
    Image sixImage;
    Image sevenImage;
    Image eightImage;

    // Start is called before the first frame update
    void Awake()
    {
        firstImage = first.GetComponent<Image>();
        secondImage = second.GetComponent<Image>();
        thirdImage = third.GetComponent<Image>();
        fourthImage = fourth.GetComponent<Image>();
        fifthImage = fifth.GetComponent<Image>();
        sixImage = six.GetComponent<Image>();
        sevenImage = seven.GetComponent<Image>();
        eightImage = eight.GetComponent<Image>();
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
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            fourthImage.color = tempColor;
            yield return null;
        }


        tempColor = fifthImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            fifthImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            fifthImage.color = tempColor;
            yield return null;
        }


        tempColor = sixImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            sixImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            sixImage.color = tempColor;
            yield return null;
        }


        tempColor = sevenImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            sevenImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(5);
        for (float i = 1; i >= 0; i -= faddingTime)
        {
            tempColor.a = i;
            sevenImage.color = tempColor;
            yield return null;
        }


        tempColor = eightImage.color;
        for (float i = 0; i <= 1; i += faddingTime)
        {
            tempColor.a = i;
            eightImage.color = tempColor;
            yield return null;
        }
        yield return new WaitForSeconds(3);
        menu.SetActive(true);
    }
}

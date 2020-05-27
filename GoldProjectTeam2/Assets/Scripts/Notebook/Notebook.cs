using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    private GameObject turnPage;
    private GameObject actualPage;

    public GameObject buttonNextPage;
    public GameObject buttonPreviousPage;

    public void NextPage()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                actualPage = gameObject.transform.GetChild(i).gameObject;
                turnPage = gameObject.transform.GetChild(i+1).gameObject;
                
                actualPage.SetActive(false);
                turnPage.SetActive(true);

                if(i+1 >= 4)
                {
                    buttonNextPage.SetActive(false);
                }
                buttonPreviousPage.SetActive(true);

                return;
            }
        }
    }

    public void PreviousPage()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                actualPage = gameObject.transform.GetChild(i).gameObject;
                turnPage = gameObject.transform.GetChild(i-1).gameObject;

                actualPage.SetActive(false);
                turnPage.SetActive(true);

                if(i-1 <= 0)
                {
                    buttonPreviousPage.SetActive(false);
                }
                buttonNextPage.SetActive(true);
                return;
            }
        }
    }
}

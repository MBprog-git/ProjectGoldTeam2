﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMB : MonoBehaviour
{
     GameObject Eljournal;
    public Transform ActivePoint;
    public Transform InactivePoint;
    public bool activated;

   /* Vector3 OldPos;
    public GameObject GOMME;
    public GameObject StockMask;
    int countMask;
    public int MaxMask;
   public int nbPixelTouch;
    public float rayonCleaner;
    public bool Cangomme;*/

    // private GameObject turnPage;
  //  private GameObject actualPage;
    public GameObject buttonNextPage;
    public GameObject buttonPreviousPage;
    public int pageactif;

    int ChargePhoto = 10;
public bool canSelfie = true;

 //   public bool[] DessinActif;
    public GameObject[] Dessin;
    public float[] DessinChrono;
    int nextdessin;


   
    void Start()
    {
        Eljournal = GameManager.instance.Journal;
    }

    void Update()
    {
        DrawingEvolution();

       

    }

    public void CallIn()
    {
        Eljournal.transform.position = ActivePoint.transform.position;
        activated = true;
       // countMask = 0;
    }
    public void CallOut()
    {
        Eljournal.transform.position = InactivePoint.transform.position;
        activated = false;
       /* Cangomme = false;
        DeleteMask();
        countMask = 0;*/
    }

    public void PageV2(bool next)
    {
        if (Dessin[pageactif] != null)
        {
            Dessin[pageactif].SetActive(false);

        }
        if (next)
        {
        pageactif++;
        buttonPreviousPage.SetActive(true);
        }
        else
        {
            pageactif--;
            buttonNextPage.SetActive(true);
        }

        if(Dessin[pageactif] != null)
        {

        Dessin[pageactif].SetActive(true);
        }
        if (pageactif == Dessin.Length -1)
        {
            buttonNextPage.SetActive(false);
        }
        if(pageactif == 0)
        {
        buttonPreviousPage.SetActive(false);

        }
       /* Cangomme = false;
        DeleteMask();*/
    }


    public void DrawingEvolution()
    {
        for(int i=0; i<Dessin.Length; i++)
        {
            if (Dessin[i]!=null)
            {
                DessinChrono[i] += Time.deltaTime;
                
                
                
                    Dessin[i].GetComponent<PhotoAction>().EFFET(DessinChrono[i]);  

            }
        }
    }


    public void AddItems(GameObject go)
    {
        if (ChargePhoto > 0)
        {
            for (int i = 1; i < Dessin.Length; i++)
            {
                if (Dessin[i] == null)
                {
                    ChargePhoto--;
                    Dessin[i] = go;
                    DessinChrono[i] = 0;
                    return;
                }
            }
        }
       

       //EFFET inventaire plein

    }

    public void RemoveItems()
    {
        if(pageactif == 0)
        {
            return; //Photo Humaine
        }
        Dessin[pageactif].GetComponent<PhotoAction>().DiscardPhoto();
        Dessin[pageactif].SetActive(false);

        for (int i = pageactif; i < Dessin.Length; i++)
        {

            if (i + 1 == Dessin.Length)
            {
                Dessin[i] = null;


            }
            else
            {
                Dessin[i] = Dessin[i + 1];
                DessinChrono[i] = DessinChrono[i + 1];

            }

        }

        Dessin[pageactif].SetActive(true);


    }

    public void Selfie()
    {
        if (canSelfie)
        {

        // modifier Dessin[0];
        }
       

    }

   /* public void Gomme()
    {

        /* //GOMME MASK
        if (Cangomme && Input.GetKey(KeyCode.Mouse0))
        {
           
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(mousePos, Vector3.back);
           

            foreach (RaycastHit2D hit2D in hits2D)
            {
                if (hit2D.collider.tag == "Dessin" && mousePos != OldPos)
                {
                    GameObject go = Instantiate(GOMME, mousePos, transform.rotation);
                    go.transform.SetParent(StockMask.transform);
                    OldPos = mousePos;
                    countMask++;

                   if (countMask > MaxMask)
                    {
                    //EFFET
         
                       
                    DeleteMask();
                    }
                   
                  // EffaceDetect(mousePos, hit2D.collider.gameObject.GetComponent<SpriteRenderer>());
                    if (nbPixelTouch > 1000)
                    {
                        Debug.Log("EFFECT");
                        nbPixelTouch = 0;
                    }
                    }
                }
            }
    }*/
    /* public void DeleteMask()
     {
         foreach(Transform child in StockMask.transform)
         {
             Destroy(child.gameObject);
         }
         countMask = 0;
     }*/

    /*
    public void NextPage()
    {
        GameObject book = gameObject.transform.GetChild(4).gameObject;
        Debug.Log(book);
        for (int i = 0; i < book.transform.childCount; i++)
        {
            if (book.transform.GetChild(i).gameObject.activeSelf == true)
            {
                actualPage = book.transform.GetChild(i).gameObject;
                turnPage = book.transform.GetChild(i + 1).gameObject;

                actualPage.SetActive(false);
                turnPage.SetActive(true);

                if (i + 1 >= 4)
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
        GameObject book = gameObject.transform.GetChild(4).gameObject;
        Debug.Log(book);
        for (int i = 0; i < book.transform.childCount; i++)
        {
            if (book.transform.GetChild(i).gameObject.activeSelf == true)
            {
                actualPage = book.transform.GetChild(i).gameObject;
                turnPage = book.transform.GetChild(i - 1).gameObject;

                actualPage.SetActive(false);
                turnPage.SetActive(true);

                if (i - 1 <= 0)
                {
                    buttonPreviousPage.SetActive(false);
                }
                buttonNextPage.SetActive(true);
                return;
            }
        }
    }*/

    /* public void AddDrawing(GameObject collider)
     {
         DessinActif[nextdessin] = true;
         nextdessin++;
         collider.SetActive(false);
     }*/



    /* public void EffaceDetect(Vector2 mousePos, SpriteRenderer maskImage)
     {
        Texture2D t = maskImage.sprite.texture;
        //Vector2 sprite_size = GetComponent<SpriteRenderer>().sprite.rect.size;
     Vector2 min = new Vector2(mousePos.x - rayonCleaner, mousePos.y - rayonCleaner);
     Vector2 max = new Vector2(mousePos.x + rayonCleaner, mousePos.y + rayonCleaner);
        
        Debug.Log(mousePos);
  
       // Debug.Log(min+"/"+max);

                 for (int i = (int) min.x; i <= max.x; i++)
                 {
                     for (int j = (int) min.y; j <= max.y; j++)
                     {
             
                        // if (Vector2.Distance(new Vector2(i, j), mousePos) <= rayonCleaner)
                         {
                    Debug.Log(t.GetPixel(i, j));
                             if (t.GetPixel(i, j).a == 0.0f)
                             {
                Debug.Log("Hoy");
                                 t.SetPixel(i, j,  Color.clear);
                        t.Apply();
                                                nbPixelTouch += 1;

                       /* Texture2D t = maskImage.sprite.texture;
                        Color32[] pix = t.GetPixels32();
                        Debug.Log(pix.Length);
                    }

                    }
                     }
                 }
     }
    private void OnDrawGizmos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 min = new Vector2(mousePos.x - rayonCleaner, mousePos.y - rayonCleaner);
        Vector2 max = new Vector2(mousePos.x + rayonCleaner, mousePos.y + rayonCleaner);
        mousePos.z = 0;
        Gizmos.DrawCube(mousePos,Vector3.one * rayonCleaner);
    }*/
}

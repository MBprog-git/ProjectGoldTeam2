using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMB : MonoBehaviour
{
     GameObject Eljournal;
    public Transform ActivePoint;
    public Transform InactivePoint;
    public bool activated;

    Vector3 OldPos;
    public GameObject GOMME;
    public GameObject StockMask;
    public bool Cangomme;

    private GameObject turnPage;
    private GameObject actualPage;
    public GameObject buttonNextPage;
    public GameObject buttonPreviousPage;

    int countMask;
   public int nbPixelTouch;

    public bool[] DessinActif;
    public float[] DessinChrono;
    int nextdessin;

    public float rayonCleaner;

   
    void Start()
    {
        Eljournal = GameManager.instance.Journal;

    }

    void Update()
    {

        //GOMME MASK
        if (Cangomme && Input.GetKey(KeyCode.Mouse0))
        {
           
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(mousePos, Vector3.back);
           

            foreach (RaycastHit2D hit2D in hits2D)
            {
                if (hit2D.collider.tag == "Dessin" && mousePos != OldPos)
                {
                   /* GameObject go = Instantiate(GOMME, mousePos, transform.rotation);
                    go.transform.SetParent(StockMask.transform);
                    OldPos = mousePos;
                    countMask++;

                   if (countMask > 20)
                    {
                    //EFFET
                    Debug.Log("EFFET DESSIN");
                        GameManager.instance.TestFonct();
                    //DeleteMask();
                    }*/
                   
                   EffaceDetect(mousePos, hit2D.collider.gameObject.GetComponent<SpriteRenderer>());
                    /*if (nbPixelTouch > 1000)
                    {
                        Debug.Log("EFFECT");
                        nbPixelTouch = 0;
                    }*/
                    }
                }
            }

        DrawingEvolution();
    }

    public void CallIn()
    {
        Eljournal.transform.position = ActivePoint.transform.position;
        activated = true;
        countMask = 0;
    }
    public void CallOut()
    {
        Eljournal.transform.position = InactivePoint.transform.position;
        activated = false;
        Cangomme = false;
        DeleteMask();
        countMask = 0;
    }

    public void DeleteMask()
    {
        foreach(Transform child in StockMask.transform)
        {
            Destroy(child.gameObject);
        }
        countMask = 0;
    }

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
    }

    public void AddDrawing(GameObject collider)
    {
        DessinActif[nextdessin] = true;
        nextdessin++;
        collider.SetActive(false);
    }

    public void DrawingEvolution()
    {
        for(int i=0; i<DessinActif.Length; i++)
        {
            if (DessinActif[i])
            {
                DessinChrono[i] -= Time.deltaTime;
                if (DessinChrono[i] < 0)
                {
                //effet
                }
            }
        }
    }

     public void EffaceDetect(Vector2 mousePos, SpriteRenderer maskImage)
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
                        Debug.Log(pix.Length);*/
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
    }
}

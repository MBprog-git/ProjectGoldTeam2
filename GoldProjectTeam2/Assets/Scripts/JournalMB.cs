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

    int countMask;

    // Start is called before the first frame update
    void Start()
    {
        Eljournal = GameManager.instance.Journal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cangomme && Input.GetKey(KeyCode.Mouse0))
        {
           
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(mousePos, Vector3.forward);
            mousePos.z = 0;

            foreach (RaycastHit2D hit2D in hits2D)
            {
                if (hit2D.collider.tag == "Dessin" && mousePos != OldPos)
                {
                        GameObject go = Instantiate(GOMME, mousePos, transform.rotation);
                        go.transform.SetParent(StockMask.transform);
                        OldPos = mousePos;
                        countMask++;

                        if (countMask > 20)
                        {
                        //EFFET
                        Debug.Log("EFFET DESSIN");
                        DeleteMask();
                        }
                    }
                }
            }
            
        
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
}

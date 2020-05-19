using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonMB : MonoBehaviour
{
    public int ActionID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Action()
    {
        switch (ActionID)
        {
            case 1:
                if (!GameManager.instance.Journal.GetComponent<JournalMB>().activated)
                {
                    GameManager.instance.Journal.GetComponent<JournalMB>().CallIn();
                }
                break;
            
            case 2:
                GameManager.instance.Journal.GetComponent<JournalMB>().CallOut();
                break; 
          /*  case 3:
                GameManager.instance.Journal.GetComponent<JournalMB>().Cangomme = !GameManager.instance.Journal.GetComponent<JournalMB>().Cangomme;
                break;
            case 4:
                GameManager.instance.Journal.GetComponent<JournalMB>().NextPage();
                break;
            case 5:
                GameManager.instance.Journal.GetComponent<JournalMB>().PreviousPage();
                break;   */  
            
            case 6:
                GameManager.instance.Journal.GetComponent<JournalMB>().PageV2(false);
                break;   
            
            case 7:
                GameManager.instance.Journal.GetComponent<JournalMB>().PageV2(true);
                break; 
            
            case 8:
                GameManager.instance.Journal.GetComponent<JournalMB>().RemoveItems();
                break; 
            
            case 9:
                GameManager.instance.Journal.GetComponent<JournalMB>().Selfie();
                break;
            
            case 10:
               /* GameManager.instance.Journal.GetComponent<JournalMB>().AddItems(transform.parent.gameObject.GetComponent<PhotoZone>().Myphoto);
                transform.parent.gameObject.SetActive(false);*/
                GameManager.instance.Journal.GetComponent<JournalMB>().AddItems(GameManager.instance.Photostock);

                break;
        }
    }
}

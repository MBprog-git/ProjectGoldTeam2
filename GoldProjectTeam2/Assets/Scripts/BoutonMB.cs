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
            case 3:
                GameManager.instance.Journal.GetComponent<JournalMB>().Cangomme = !GameManager.instance.Journal.GetComponent<JournalMB>().Cangomme;
                break;
        }
    }
}

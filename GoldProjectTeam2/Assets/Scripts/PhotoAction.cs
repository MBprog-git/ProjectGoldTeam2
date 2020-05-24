using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoAction : MonoBehaviour
{
    public int IdAction;
    bool tpOnce;

    

    /*iDAction
     0=Rien
         1=Fleur
         2=Eau
         3=Voiture
         4=Corbac
         
         */
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void EFFET(float chrono)
    {
        switch (IdAction)
        {
            case 1:
                
                if (chrono > 30)
                {
                    //changement anim
                    GameManager.instance.Player.GetComponent<PlayerMovement>().speed = GameManager.instance.Player.GetComponent<PlayerMovement>().speed * 0.85f;
                }

                else if (chrono > 7)
                {
                    GameManager.instance.Player.GetComponent<PlayerMovement>().speed = GameManager.instance.Player.GetComponent<PlayerMovement>().speed * 0.93f;
                }

                break;      
            
            case 2:
                
                if (chrono > 45)
                {
                    GameManager.instance.Journal.GetComponent<JournalMB>().canSelfie = false;
                    //Tempete
                        GameManager.instance.mister.GetComponent<Mister>().speed = GameManager.instance.mister.GetComponent<Mister>().speed * 0.70f;
      
                }

                else if (chrono > 15)
                {
                    //Effet goutte
                }

                break;     
            
            case 3:
                
                if (chrono > 50)
                {
                    //Passage voiture
                    if (!tpOnce)
                    {
                    GameManager.instance.mister.transform.position = new Vector2(GameManager.instance.mister.GetComponent<Mister>().almostInScreenDistance, GameManager.instance.mister.transform.position.y) ;
                        tpOnce = true;
                    }

                }

                else if (chrono > 35)
                {
                    //Effet lumière
                }

                break;    
            
            case 4:
                
                if (chrono > 35)
                {
                    GameManager.instance.Player.GetComponent<PlayerMovement>().Canhide = false;
                    GameManager.instance.Player.GetComponent<PlayerMovement>().speed = GameManager.instance.Player.GetComponent<PlayerMovement>().speed * 1.10f;
                }

                else if (chrono > 10)
                {
                    //Croa + Visuel corbac
                }

                break;


        }
    }

    public void DiscardPhoto() {

        switch (IdAction)
        {
            case 1:
                GameManager.instance.Player.GetComponent<PlayerMovement>().speed = GameManager.instance.Player.GetComponent<PlayerMovement>().speedBase;
                    //anim
                                                break;
            case 2:
                //effet
                GameManager.instance.Journal.GetComponent<JournalMB>().canSelfie = true;
                GameManager.instance.mister.GetComponent<Mister>().speed = GameManager.instance.mister.GetComponent<Mister>().speedBase;
                break;
            case 3:
                //effet visuel
                tpOnce = false;
                break;
            case 4:
                GameManager.instance.Player.GetComponent<PlayerMovement>().Canhide = true;
                //effet visuel


                break;
        }

    
    
    }
}

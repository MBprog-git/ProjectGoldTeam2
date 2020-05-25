using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoAction : MonoBehaviour
{
    public int IdAction;
    bool tpOnce;
    bool flashOnce;
     float FleurAction1;
     float FleurAction2;   
     float EauAction1;
     float EauAction2;
     float CarAction1;
     float CarAction2;
     float CorbacAction1;
     float CorbacAction2;

    /*iDAction
     0=Rien
         1=Fleur
         2=Eau
         3=Voiture
         4=Corbac
         
         */
    void Start()
    {
         FleurAction1 = GameManager.instance.FleurAction1;
         FleurAction2 = GameManager.instance.FleurAction2;
         EauAction1 = GameManager.instance.EauAction1;
         EauAction2 = GameManager.instance.EauAction2;
         CarAction1 = GameManager.instance.CarAction1;
         CarAction2 = GameManager.instance.CarAction2;
         CorbacAction1  = GameManager.instance.CorbacAction1;
         CorbacAction2 = GameManager.instance.CorbacAction2;
       
        this.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void EFFET(float chrono)
    {
        float Speedo = GameManager.instance.Player.GetComponent<PlayerMovement>().speedBase;
        switch (IdAction)
        {
           
            case 1:
                
                if (chrono > FleurAction2)
                {
                    //changement anim
                    Speedo = Speedo * 0.85f;
                   // Debug.Log(chrono + "/" + FleurAction2);
                  
                }

                else if (chrono > FleurAction1)
                {
                    Speedo = Speedo * 0.93f;
                }

                break;      
            
            case 2:
                
                if (chrono > EauAction2)
                {
                    GameManager.instance.Journal.GetComponent<JournalMB>().canSelfie = false;
                    //Tempete
                        GameManager.instance.mister.GetComponent<Mister>().speed = GameManager.instance.mister.GetComponent<Mister>().speedBase * 0.70f;
      
                }

                else if (chrono > EauAction1)
                {
                    //Effet goutte
                }

                break;     
            
            case 3:
                
                if (chrono > CarAction2)
                {
                    //Passage voiture
                    if (!tpOnce)
                    {
                    GameManager.instance.mister.transform.position = new Vector2(GameManager.instance.mister.GetComponent<Mister>().almostInScreenDistance, GameManager.instance.mister.transform.position.y) ;
                        tpOnce = true;
                    }

                }

                else if (chrono > CarAction1)
                {
                    if (!flashOnce)
                    {

                    GameManager.instance.Journal.GetComponent<JournalMB>().FlashCar.color = new Color(1, 1, 1, 1);
                        flashOnce = true;
                    }
                }

                break;    
            
            case 4:
                
                if (chrono > CorbacAction2)
                {
                    GameManager.instance.Player.GetComponent<PlayerMovement>().Canhide = false;
                    Speedo = Speedo * 1.10f;
                }

                else if (chrono > CorbacAction1)
                {
                    //Croa + Visuel corbac
                }

                break;

        }
        GameManager.instance.Player.GetComponent<PlayerMovement>().speed = Speedo;
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
                flashOnce = false;
                break;
            case 4:
                GameManager.instance.Player.GetComponent<PlayerMovement>().Canhide = true;
                //effet visuel


                break;
        }

    
    
    }
}

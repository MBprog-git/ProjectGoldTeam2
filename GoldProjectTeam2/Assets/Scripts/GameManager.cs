using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Camera cam;
    public GameObject Player;
    public GameObject Hideout;
    public float DecalHid1;
    public float DecalHid2;

    public GameObject Journal;
    public Text Clocky;
    public float RythmeClock;
    float timerClock;
    public int heure= 12;
    public int minute;

    public GameObject mister;
    public Vector2 misterPosition;

//public      SpriteRenderer s;


 public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;

      //  TestFonct();

        timerClock = RythmeClock;

    }
    
    void Start()
    {
    }

   
    void Update()
    {
        timerClock -= Time.deltaTime;
        if (timerClock < 0)
        {
            UpdateTime();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 Mouspos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D[] hits2D = Physics2D.RaycastAll(Mouspos, Vector3.forward);
            foreach (RaycastHit2D hit2D in hits2D)
            {
                if (hit2D.collider.GetComponent<BoutonMB>() != null)
                {
                    hit2D.collider.GetComponent<BoutonMB>().Action();
                    break;
                }   
                if (hit2D.collider.tag == "Hideout")
                {
                    Player.GetComponent<PlayerMovement>().HideMe();
                    break;
                }
            }
        }
    }
    public void doExitGame()
    {
        Application.Quit();
    }
    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
     
    }

    void UpdateTime()
    {
        minute ++;
        if(minute == 6)
        {
            minute = 0;
            heure++;
             
        }

        Clocky.text = heure + " : " + minute + "0"; 


        timerClock = RythmeClock;

        HourEvent();
    }

    public void HourEvent()
    {
        switch(heure)
        {
            //case 17:
            //    SpawnMan();
            //    break;
        }
    }

    public void SpawnHid()
    {
        Vector2 pos1 = new Vector2(Player.transform.position.x + DecalHid1, Player.transform.position.y);
        Vector2 pos2 = new Vector2(Player.transform.position.x + DecalHid2, Player.transform.position.y);

        Instantiate(Hideout, pos1, transform.rotation);
        Instantiate(Hideout, pos2, transform.rotation);
    }

    public void SpawnMan()
    {
        Instantiate(mister, misterPosition, transform.rotation);
    }

    /* public void TestFonct()
     {
         Texture2D t = s.sprite.texture;
          Color32[] pix = t.GetPixels32();
          Debug.Log(pix.Length);

         List<Color> pix = new List<Color>();
         pix.AddRange(t.GetPixels());

         Debug.Log("Transparent : " + pix.FindAll(x => x == Color.clear).Count);
         Debug.Log("White : " + pix.FindAll(x => x == Color.white).Count);
         Debug.Log("Black : " + pix.FindAll(x => x == Color.black).Count);
     }*/
}

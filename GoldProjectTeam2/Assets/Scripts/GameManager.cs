using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Camera cam;
    public GameObject Journal;
    public Text Clocky;
    public float RythmeClock;
    float timerClock;
    public int heure= 12;
    public int minute;

public      SpriteRenderer s;


 public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;

        TestFonct();

        timerClock = RythmeClock;

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
    }


    public void TestFonct()
    {
        Texture2D t = s.sprite.texture;
        /* Color32[] pix = t.GetPixels32();
         Debug.Log(pix.Length);
         */
        List<Color> pix = new List<Color>();
        pix.AddRange(t.GetPixels());

        Debug.Log("Transparent : " + pix.FindAll(x => x == Color.clear).Count);
        Debug.Log("White : " + pix.FindAll(x => x == Color.white).Count);
        Debug.Log("Black : " + pix.FindAll(x => x == Color.black).Count);
    }
}

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


 public static GameManager instance;

    void Awake()
    {
        timerClock = RythmeClock;

        if (instance == null)
            instance = this;
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
}

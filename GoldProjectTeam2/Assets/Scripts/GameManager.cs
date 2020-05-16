using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayMultipleSound))]
public class GameManager : MonoBehaviour
{
    public Camera cam;
    public GameObject Player;
    public GameObject QTEBalance;
    public GameObject QTERythme;
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
    //public Vector2 misterPosition;

    private PlayMultipleSound playSound;

    public int timeSwitchToDemiLune = 19;
    public int timeSwitchToLune = 21;

    public Image graindCouleur;

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
        playSound = GetComponent<PlayMultipleSound>();
        Clocky.text = heure + " : " + minute + "0";
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
                    Player.GetComponent<PlayerMovement>().HideMe(hit2D.collider.gameObject);
                    break;
                }
            }
        }

        if (heure == timeSwitchToDemiLune && playSound.GetEnumOfAudioPlaying() != TYPE_AUDIO.MusiqueAmbianceDemiLune)
        {
            playSound.PlaySound(TYPE_AUDIO.MusiqueAmbianceDemiLune);
            graindCouleur.color = new Color( 0,0,0,0.4f);
        }
        else if(heure == timeSwitchToLune && playSound.GetEnumOfAudioPlaying() != TYPE_AUDIO.MusiqueAmbianceLune)
        {
            playSound.PlaySound(TYPE_AUDIO.MusiqueAmbianceLune);
            graindCouleur.color = new Color(255, 0, 0, 0.4f);
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

   /* public void SpawnMan()
    {
        Instantiate(mister, misterPosition, transform.rotation);
    }*/

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

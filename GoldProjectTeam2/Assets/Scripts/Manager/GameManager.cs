using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;

[RequireComponent(typeof(PlayMultipleSound))]
public class GameManager : MonoBehaviour
{

     [Header("Timer Effet Photo")]
    [Space]

    public float FleurAction1 = 7;
    public float FleurAction2 = 30;
    public float EauAction1 =15;
    public float EauAction2=45;
    public float CarAction1=35;
    public float CarAction2=50;
    public float CorbacAction1=10;
    public float CorbacAction2=35;

    [Header("Cachette")]
    [Space]
    public float DecalHid1;
    public float DecalHid2;

    [Header("Temps")]
    [Space]
    [Tooltip("X secondes IRL = 10 minutes en jeu")]
    public float RythmeClock;
    public int heure= 12;
    public int minute;
    public int timeSwitchToDemiLune = 19;
    public int timeSwitchToLune = 21;




    [Header("GameObject à brancher")]
    [Space]
    public Light2D SceneLight;
    public Camera cam;
    public GameObject Player;
    public GameObject Journal;
    public GameObject QTEBalance;
    public GameObject qteZone;
    public GameObject QTERythme;
    public GameObject mister;
    

    public GameObject FlecheDroite;
    public GameObject FlecheGauche;
    public GameObject particules1;
    public GameObject particules2;
    public GameObject particules3;
    public GameObject Fondu;
    public GameObject Bagnole;
    public GameObject CantSelfie;
    public GameObject ParticuleEau;
    public GameObject Hideout;
    public Text Clocky;
    public GameObject ButtonSelfie;
    public GameObject ButtonPhoto;
    public GameObject ButtonJournal;
    public GameObject TxtPhotoCharge;
    public GameObject HideUi;
    // public Image graindCouleur;

    int frame;

    [HideInInspector]
    public GameObject Photostock;
    [HideInInspector]
    public bool CorbacSound;
    [HideInInspector]
    public bool IsMoving;
    float Albedo = 1;
    Image spButtonJournal;
    Text spTextCharge;
    SpriteRenderer spButtonSelfie;
    SpriteRenderer spButtonPhoto;
    SpriteRenderer spCantself;
    Image spFlecheDroite;
    Image spFlecheGauche;
    private PlayMultipleSound playSound;
    float timerVibro;
    float timerClock;


    //public Vector2 misterPosition;
    //public      SpriteRenderer s;
   // bool Selfie = true;

    public static GameManager instance;

    void Awake()
    {
        //   Fondu.color = new Color(Fondu.color.r, Fondu.color.g, Fondu.color.b, 1);
        spFlecheDroite = FlecheDroite.GetComponent<Image>();
        spFlecheGauche = FlecheGauche.GetComponent<Image>();
        spCantself = CantSelfie.GetComponent<SpriteRenderer>();
         spButtonSelfie = ButtonSelfie.GetComponent<SpriteRenderer>();
         spButtonPhoto = ButtonPhoto.GetComponent<SpriteRenderer>();
         spButtonJournal = ButtonJournal.GetComponent<Image>();
        spTextCharge = TxtPhotoCharge.GetComponent<Text>();
        if (instance == null)
            instance = this;

        //  TestFonct();
        timerVibro = 120;
        timerClock = RythmeClock;

    }
    
    void Start()
    {
        playSound = GetComponent<PlayMultipleSound>();
      
        Clocky.text = heure + " : " + minute + "0";
        playSound.PlaySound(TYPE_AUDIO.MusiqueAmbianceSoleil);


    }

   
    void Update()
    {
        if(frame == 5)
        {

        Fondu.GetComponent<Animator>().SetTrigger("start");
            frame++;
        }else if (frame < 5)
        {
            frame++;
        }

        VibraAleatoire();
        FadeUi();
        timerClock -= Time.deltaTime;
        if (timerClock < 0)
        {
            UpdateTime();
        }

       /* if (Input.GetKeyDown(KeyCode.M))
        {
          
        }*/
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

    


    }

    public void FadeUi()
    {
      /*  if (Fondu.color.a > 0)
        {
            Fondu.color = new Color(Fondu.color.r, Fondu.color.g, Fondu.color.b, Fondu.color.a - Time.deltaTime) ;
        }*/

        if (!IsMoving && Albedo<1) {
            Albedo += Time.deltaTime;


        }
        else if(IsMoving && Albedo > 0)
        {
            Albedo -= Time.deltaTime;

        }
             spButtonSelfie.color = new Color(spButtonSelfie.color.r, spButtonSelfie.color.g, spButtonSelfie.color.b, Albedo) ;
             spButtonPhoto.color = new Color(spButtonPhoto.color.r, spButtonPhoto.color.g, spButtonPhoto.color.b, Albedo);
             spButtonJournal. color = new Color(spButtonJournal.color.r, spButtonJournal.color.g, spButtonJournal.color.b, Albedo);
        spTextCharge. color = new Color(spTextCharge.color.r, spTextCharge.color.g, spTextCharge.color.b, Albedo);
        spCantself. color = new Color(spCantself.color.r, spCantself.color.g, spCantself.color.b, Albedo);
        spFlecheGauche. color = new Color(spFlecheGauche.color.r, spFlecheGauche.color.g, spFlecheGauche.color.b, Albedo);
        spFlecheDroite. color = new Color(spFlecheDroite.color.r, spFlecheDroite.color.g, spFlecheDroite.color.b, Albedo);
        
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

        if (SceneLight.intensity > 0.5f)
        {

            SceneLight.intensity -= 0.01f;
        }

        timerClock = RythmeClock;

        HourEvent();
    }

    public void HourEvent()
    {
        switch(heure)
        {


            
            case 18:
                particules1.SetActive(false);
                particules2.SetActive(true);

                if( playSound.GetEnumOfAudioPlaying() != TYPE_AUDIO.MusiqueAmbianceDemiLune)
                {
                    playSound.PlaySound(TYPE_AUDIO.MusiqueAmbianceDemiLune);
                  
                }

            break;   
            
            case 19:
                particules2.SetActive(false);
                particules2.SetActive(true);
                 if (playSound.GetEnumOfAudioPlaying() != TYPE_AUDIO.MusiqueAmbianceLune)
                {
                    playSound.PlaySound(TYPE_AUDIO.MusiqueAmbianceLune);
                  
                }

                break; 
            
        }
    }

    public void SpawnHid()
    {
     /*   Vector2 pos1 = new Vector2(Player.transform.position.x + DecalHid1, Player.transform.position.y);
        Vector2 pos2 = new Vector2(Player.transform.position.x + DecalHid2, Player.transform.position.y);

        Instantiate(Hideout, pos1, transform.rotation);
        Instantiate(Hideout, pos2, transform.rotation);*/
    }
    public void VibraAleatoire()
    {


        if (timerVibro < 0)
        {
        Handheld.Vibrate();
            int rand = Random.Range(45, 100);
            timerVibro = rand;
        }
        else
        {
            timerVibro -= Time.deltaTime;

        }


    }

    public void PhotoSwitch(bool Selfie)
    {
        if (Selfie)
        {
            ButtonSelfie.SetActive(false);
            ButtonPhoto.SetActive(true);
                CantSelfie.SetActive(false);

        }
        else
        {
            ButtonSelfie.SetActive(true);
            ButtonPhoto.SetActive(false);
            if (!Journal.GetComponent<JournalMB>().canSelfie)
            {
                CantSelfie.SetActive(true);
            }
        }

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

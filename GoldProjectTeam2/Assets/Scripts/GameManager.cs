using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Camera cam;
    public GameObject Journal;

 public static GameManager instance;
    void Awake()
    {
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
}

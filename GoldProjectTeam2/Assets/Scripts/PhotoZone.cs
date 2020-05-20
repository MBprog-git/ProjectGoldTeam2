using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoZone : MonoBehaviour
{
    public GameObject Myphoto;
    public GameObject PhotoBouton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
        //   PhotoBouton.SetActive(true);

            GameManager.instance.PhotoSwitch(true);
            GameManager.instance.Photostock = Myphoto;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
           // PhotoBouton.SetActive(false);


            GameManager.instance.PhotoSwitch(false);
        }
    }
}

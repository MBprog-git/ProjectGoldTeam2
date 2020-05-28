using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCine : MonoBehaviour
{
     float chrono = 0;

    public GameObject Menu;

    public SpriteRenderer Visage;
    public SpriteRenderer fond;
    public SpriteRenderer Text1;
    public SpriteRenderer Text2;
    public SpriteRenderer Text3;
    
    public AudioClip Slash;
    AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(Slash);
    }

    // Update is called once per frame
    void Update()
    {
        chrono += Time.deltaTime;
        CinemaLoose();
    }

    void CinemaLoose()
    {
        if (Visage.color.a < 1 && chrono>1)
        {

            Visage.color = new Color(Visage.color.r, Visage.color.g, Visage.color.b, Visage.color.a + Time.deltaTime * 0.5f);
            fond.color = new Color(fond.color.r, fond.color.g, fond.color.b, fond.color.a + Time.deltaTime * 0.5f);
        }

        if (Visage.color.a > 1 && Text1.color.a <1)
        {
            Text1.color = new Color(Text1.color.r, Text1.color.g, Text1.color.b, Text1.color.a + Time.deltaTime * 0.5f);

        }   
        
        if (Text1.color.a > 0.75f && Text2.color.a <1)
        {
            Text2.color = new Color(Text2.color.r, Text2.color.g, Text2.color.b, Text2.color.a + Time.deltaTime * 0.5f);

        }  
        
        if (Text2.color.a > 0.75f && Text3.color.a <1)
        {
            Text3.color = new Color(Text3.color.r, Text3.color.g, Text3.color.b, Text3.color.a + Time.deltaTime * 0.5f);

        }

        if (chrono > 10)
        {
            Menu.SetActive(true);
        }
    }
}

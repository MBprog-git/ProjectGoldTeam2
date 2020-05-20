using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    GameObject player;
    SpriteRenderer sp;
    public float MaxDist;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.Player;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(dist);
        if (dist < MaxDist)
        {
            float Albedo = (1-(dist / MaxDist));

            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b,Albedo);


            Debug.Log(Albedo);

        }
    }
}

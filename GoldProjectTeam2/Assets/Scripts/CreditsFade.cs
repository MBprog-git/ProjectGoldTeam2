using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsFade : MonoBehaviour
{
    public SpriteRenderer[] Credit;
    public float Albedo = 0;
    public float speed;


    void Update()
    {
        foreach(SpriteRenderer sp in Credit)
        {
            sp.color = new Color(sp.color.r, sp.color.g, sp.color.b, Albedo);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Albedo += Time.deltaTime * speed;

        }
        else
        {
            Albedo -= Time.deltaTime * speed;
        }
    }
}

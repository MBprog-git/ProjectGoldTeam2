using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mister : MonoBehaviour
{
    public GameObject player;

    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;       
    }
}

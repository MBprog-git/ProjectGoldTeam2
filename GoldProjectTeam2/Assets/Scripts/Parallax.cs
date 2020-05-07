using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 0.05f;
    private float lastPosX;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            Debug.LogError("NO PLAYER ASSIGNED FOR PARRALAX");
            Destroy(this);
        }
        else
        {
            lastPosX = player.transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPosX > player.transform.position.x)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + speed, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            lastPosX = player.transform.position.x;
        }
        else if (lastPosX < player.transform.position.x)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - speed, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            lastPosX = player.transform.position.x;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorsMap : MonoBehaviour
{

    [SerializeField] private Transform posPlayer;

    private void Update()
    {
        transform.position = new Vector3( posPlayer.position.x, transform.position.y, transform.position.z );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public float spawnRate = 0.1f;
    //public float spawnCoolDown = 1.5f;
    public GameObject spawnPoint;
    public List<GameObject> listSpawnPoint = new List<GameObject>();

    private float randomValue;
    private float addedValue;
    private float whichNote;

    private Vector2 spawnPosition;

    public GameObject note;
    public GameObject longNote;

    private GameObject noteToSpawn;

    void Start()
    {
        addedValue = spawnRate;
    }

    void Update()
    {
        CompareValue();
    }

    void GetRandomValue()
    {
        randomValue = Random.value;    
    }

    void CompareValue()
    {
        WhichNote();
        if(addedValue >= randomValue)
        {
            spawnPosition = listSpawnPoint[Random.Range(0, 2)].transform.position;
            GameObject spawnedNote = Instantiate(noteToSpawn, spawnPosition, Quaternion.identity);
            spawnedNote.transform.SetParent(spawnPoint.transform);
            GetRandomValue();
            addedValue = spawnRate;
            //StartCoroutine(CoolDown());
            return;
        }
        addedValue += spawnRate;
    }

    void WhichNote()
    {
        whichNote = Random.value;
        if(whichNote >= 0.5f)
        {
            noteToSpawn = note;
            return;
        }
        noteToSpawn = longNote;
    }
    //IEnumerator CoolDown()
    //{
    //    Debug.Log("test");
    //    yield return new WaitForSeconds(spawnCoolDown);
    //}

}

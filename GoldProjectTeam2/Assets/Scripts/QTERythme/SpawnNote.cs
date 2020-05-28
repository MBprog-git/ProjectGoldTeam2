using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public float spawnRate = 0.1f;
    public GameObject spawnPoint;
    public List<GameObject> listSpawnPoint = new List<GameObject>();

    private float randomValue;
    private float addedValue;
    private float whichNote;

    private Vector2 spawnPosition;

    public List<GameObject> listNote = new List<GameObject>();
    private GameObject noteToDestroy;

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
        if(addedValue >= randomValue && addedValue >= 1)
        {
            spawnPosition = listSpawnPoint[Random.Range(0, 2)].transform.position;
            GameObject spawnedNote = Instantiate(noteToSpawn, spawnPosition, Quaternion.identity);
            listNote.Add(spawnedNote);
            spawnedNote.transform.SetParent(spawnPoint.transform);
            GetRandomValue();
            addedValue = spawnRate;
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

    public void ClearList()
    {
        
        for (int i = 0; i < listNote.Count; i++)
        {
            noteToDestroy = listNote[i];
            listNote.Remove(noteToDestroy);
            Destroy(noteToDestroy.gameObject);
        }
    }
}

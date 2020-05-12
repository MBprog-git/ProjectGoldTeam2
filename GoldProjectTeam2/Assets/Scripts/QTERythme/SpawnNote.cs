using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNote : MonoBehaviour
{
    public float spawnRate = 0.1f;
    public float spawnCoolDown = 1.5f;

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
        spawnPosition = this.transform.position;
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
            Instantiate(noteToSpawn, spawnPosition, Quaternion.identity);
            GetRandomValue();
            addedValue = spawnRate;
            StartCoroutine(CoolDown());
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

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(spawnCoolDown);
    }

}

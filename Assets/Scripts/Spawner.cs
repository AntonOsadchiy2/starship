using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] loot;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, loot.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(loot[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}

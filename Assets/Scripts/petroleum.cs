using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petroleum : MonoBehaviour
{


    public int MaxFishinMap;
    [Space(100)]
    public GameObject allCrop;
    [SerializeField] private GameObject CropPrefab;


    private int limit;
    private int phase;
    private int model;
    private int growing;
    //public Sprite[,] reproduction = new Sprite[4, 4];
    private IEnumerator Spawn;


    [SerializeField] private float maxX, minX, maxY, minY;
    void Start()
    {
        StartSpawn(10);

        InvokeRepeating("SpawnAtStart", 0.0f, 1f);
    }

    private void StartSpawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn = SpawnCrop(0.1f);
            StartCoroutine(Spawn);
        }
    }

    private void SpawnAtStart()
    {
        int fishCount = allCrop.transform.childCount;
        if (fishCount <= MaxFishinMap)
        {
            StartCoroutine(SpawnCrop(1.0f));
        }
    }

    private IEnumerator SpawnCrop(float time)
    {

        GameObject fish;

        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        yield return new WaitForSeconds(time);
        fish = Instantiate(CropPrefab, new Vector3(x, y, 4f), Quaternion.identity);
        fish.transform.SetParent(allCrop.transform);
    }
}

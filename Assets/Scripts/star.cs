using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    [SerializeField] private GameObject allStar;
    [SerializeField] private GameObject starPrefab;
    public List<GameObject> starList;
    private float size;
    [SerializeField] private float maxX, minX, maxY, minY;

    void Start()
    {
        starList = new List<GameObject>();
        StartSpawn(10);
    }

    private void StartSpawn(int number)
    {
        GameObject star;
        for (int i = 0; i < number; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            star = Instantiate(starPrefab, new Vector3(x, y, 0f), Quaternion.identity);
            size = Random.value + (float)0.1;
            star.transform.localScale *= size;
            starList.Add(Instantiate(starPrefab, new Vector3(x, y, 0f), Quaternion.identity));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green : MonoBehaviour
{
    [SerializeField] private int MaxGreenInMap;
    [SerializeField] private GameObject allGreen;
    public List<GameObject> greenList;
    [SerializeField] private GameObject greenPrefab;
    [SerializeField] private GameObject Nuclear;

    [SerializeField] private float maxX, minX, maxY, minY;
    void Start()
    {
        greenList = new List<GameObject>();
        StartSpawn(MaxGreenInMap);
    }

    private void StartSpawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject greenplanet;

            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            greenplanet = Instantiate(greenPrefab, new Vector3(x, y, 4f), Quaternion.identity);
            greenplanet.transform.SetParent(allGreen.transform);
            x = greenplanet.transform.position.x;
            y = greenplanet.transform.position.y;
            greenList.Add(Instantiate(Nuclear, new Vector3(x, y, 0f), Quaternion.identity));
        }
    }
}

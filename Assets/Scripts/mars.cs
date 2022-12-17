using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mars : MonoBehaviour
{
    [SerializeField] private GameObject Planet;
    [SerializeField] private GameObject Oil;
    private float size;
    public List<GameObject> marsList;
    private IEnumerator Spawn;


    [SerializeField] private float maxX, minX, maxY, minY;

    void Start()
    {
        marsList = new List<GameObject>();
        SpawnPlanet(10);
    }

    private void SpawnPlanet(int number)
    {
        GameObject planet;
        for (int i = 0; i < number; i++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            planet = Instantiate(Planet, new Vector3(x, y, 0f), Quaternion.identity);
            size = Random.value + (float)0.1;
            planet.transform.localScale *= size;
            SpawnOil(planet , size);
            //fish.transform.SetParent(allCrop. transform);
        }
    }

    private void SpawnOil(GameObject Planet , float size)
    {
        GameObject oil;
        int number = (int)Random.Range(0, 6);
        
        for (int i = 0; i < number; i++)
        {
            float x = Planet.transform.position.x + Random.Range(size * (float)-2.25, size * (float)2.25);
            float y = Planet.transform.position.y + Random.Range(size * (float)-2.25, size * (float)2.25);
            oil = Instantiate(Oil, new Vector3(x, y, 0f), Quaternion.identity);
            oil.transform.localScale *= size;
            marsList.Add(Instantiate(Oil, new Vector3(x, y, 0f), Quaternion.identity));
        }
        
    }
}

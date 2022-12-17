using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipgenerate : MonoBehaviour
{

    [SerializeField] public GameObject Planet;

    private IEnumerator Spawn;


    [SerializeField] private float maxX, minX, maxY, minY;

    void Start()
    {
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
            
            //fish.transform.SetParent(allCrop. transform);
        }
    }

}

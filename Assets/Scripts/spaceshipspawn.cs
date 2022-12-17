using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceshipspawn : MonoBehaviour
{
    [SerializeField] private int startShipNumber;
    public GameObject GameManager;
    [SerializeField] private GameObject allShips;
    [SerializeField] private List<GameObject> ShipPrefabs;

    [SerializeField] private float maxX, minX, maxY, minY;
    void Start()
    {
        SpawnShip();
    }

    private void SpawnShip()
    {
        for (int i = 0; i < startShipNumber; i++)
        {
            GameObject newShip;

            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            foreach (GameObject ship in ShipPrefabs)
            {
                x = Random.Range(minX, maxX);
                y = Random.Range(minY, maxY);
                newShip = Instantiate(ship, new Vector3(x, y, 0f), Quaternion.identity);
                newShip.transform.SetParent(allShips.transform);
                if (newShip.GetComponent<ShipComponent>() != null)
                    newShip.GetComponent<ShipComponent>().ship.GameManager = GameManager;
            }
        }
    }
}

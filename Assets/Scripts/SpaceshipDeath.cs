using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Starship>() != null)
        {
            Debug.Log("Корабль сгорел");
            Destroy(collider.gameObject.GetComponent<Starship>().shipTransform.gameObject);
        }
    }
}

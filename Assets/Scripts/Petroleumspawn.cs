using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petroleumspawn : MonoBehaviour
{

    public float FoodValue;
    void Start()
    {
        LoadProperties();
    }

    private void LoadProperties()
    {
        FoodValue = Random.Range(3f, 5f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "petroleum")
        {
            int diraction = Random.Range(0, 9);

            switch (diraction)
            {
                case 0:
                    {
                        transform.position += Vector3.up;
                        break;
                    }

                case 1:
                    {
                        transform.position -= Vector3.up;
                        break;
                    }

                case 2:
                    {
                        transform.position += Vector3.right;
                        break;
                    }

                case 3:
                    {
                        transform.position -= Vector3.right;
                        break;
                    }
            }
        }
    }
}

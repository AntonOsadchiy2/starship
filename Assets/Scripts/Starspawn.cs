using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starspawn : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "star")
        {
            int diraction = Random.Range(0, 4);

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

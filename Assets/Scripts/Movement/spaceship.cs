using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spaceship : MonoBehaviour
{
    public static spaceship InstanceNew { get; set; }
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveinRight;
    Transform plant;

    public GameObject PtrTextObj;
    public GameObject NucTextObj;

    private TextMeshProUGUI PtrText;
    private TextMeshProUGUI NucText;
    //Топливо в баке
    public int PtrInUse;
    public int maxPtrInUse;

    public int NucInUse;
    public int maxNucInUse;
    //Топливо в инвентаре
    public GameObject[] Inventory;

    public int PtrStored;
    public int MaxPtrStored;

    public int NucStored;
    public int MaxNucStored;

    private float coordinateX;
    private float coordinateXTwo;
    private SpriteRenderer sprite;

    private Rigidbody2D rb;

    public GameObject[] food;
    GameObject closest;


    public string nearest;
    public Transform target;

    public GameObject[] Nuclear;
    GameObject closes;

    public string neares;
    public Transform targe;




    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        InstanceNew = this; 
        PtrText = PtrTextObj.GetComponent<TextMeshProUGUI>();
        NucText = NucTextObj.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        PtrStored = 50;
        MaxPtrStored = 500;
        NucStored = 50;
        MaxNucStored = 500;

        PtrInUse = 100;
        maxPtrInUse = 100;

        NucInUse = 100;
        maxNucInUse = 100;
        StartCoroutine(BurningFuel());
    }

    void Update()
    {
        StartCoroutine(RunRightOrLeft());
        if (coordinateX > coordinateXTwo)
        {
            sprite.flipX = false;
        }
        if (coordinateX < coordinateXTwo)
        {
            sprite.flipX = true;
        }

        food = GameObject.FindGameObjectsWithTag("petroleum");
        Nuclear = GameObject.FindGameObjectsWithTag("petroleum");
        nearest = FindClosestFuel().name;
        neares = FindClosestFuel().name;
        target = FindClosestFuel().transform;
        targe = FindClosestFuel().transform;


        if (PtrInUse > 30)
        {
            Chill();
        }

        if (PtrInUse < 30)
        {
            Angry();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "petroleum")
        {
            PtrInUse = PtrInUse + 100;
            PtrStored = PtrStored + 20; //сбор в инвентарь
        }
        if (PtrInUse > maxPtrInUse)
        {

            PtrInUse = maxPtrInUse;
        }
    }

    private void Chill()
    {
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveinRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveinRight = true;
        }
        if (moveinRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }


    private IEnumerator BurningFuel()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (PtrInUse >= 0)
                PtrInUse -= 5;
            else if (NucInUse >= 0)
                NucInUse -= 5;
            else
                Die();
            PtrText.text = "" + PtrInUse;
            NucText.text = "" + NucInUse;
        }
    }






    GameObject FindClosestFuel()
    {

        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        {

            foreach (GameObject go in food)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }

            return closest;
        }

    }


    private IEnumerator RunRightOrLeft()
    {
        coordinateX = this.gameObject.transform.position.x;
        yield return new WaitForSeconds(0.1f);
        coordinateXTwo = this.gameObject.transform.position.x;

    }
}

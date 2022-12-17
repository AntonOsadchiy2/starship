using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Starship : MonoBehaviour
{
    [SerializeField] private float speed;

    public bool isRefueling;
    private bool isEmpty;

    public GameObject GameManager;
    [SerializeField] private ShipEngine[] engines;
    [SerializeField] private ShipEngine oilStorage;

    private string refuelingEngineType;
    private int refuelingEngineNum;
    private Fuel fuelSource;

    [SerializeField] public Transform shipTransform;
    private Transform target;
    private List<GameObject> spaceStations;
    private List<GameObject> oilFields;
    private List<GameObject> stars;

    private List<float> fuelLevel;

    void Awake()
    {
        oilFields = new List<GameObject>();
        spaceStations = new List<GameObject>();
        stars = new List<GameObject>();
        
        isRefueling = false;
        isEmpty = false;
    }

    void Start()
    {
        StartCoroutine(GetFuelSources());
        StartCoroutine(BurningFuel());
    }

    void Update()
    {
        Navigating();
    }

    void OnTriggerStay2D(Collider2D collission)
    {
        if (collission.gameObject.GetComponent<Fuel>() != null)
        {
            Fuel collisionCheck = collission.gameObject.GetComponent<Fuel>();
            if (collisionCheck.type == refuelingEngineType || (collisionCheck.type == "oil" && refuelingEngineType == "oilStorage"))
            {
                Debug.Log("Начинаю заправку");
                isRefueling = true;
                fuelSource = collisionCheck;
            }
        }
    }

    private void StopRefuel()
    {
        refuelingEngineNum = -1;
        refuelingEngineType = null;
        fuelSource = null;
        target = null;
    }
    private void Navigating()
    {

        if (isEmpty == false)
        {
            if (isRefueling == false)
            {
                if (target == null)
                    target = ChooseTarget();
                else
                {
                    transform.rotation = Quaternion.LerpUnclamped(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90), speed * Time.deltaTime);
                    shipTransform.position = Vector2.MoveTowards(shipTransform.position, target.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                Debug.Log("Заправляюсь");
                if (refuelingEngineType == "oilStorage")
                    isRefueling = oilStorage.Refuel(fuelSource);
                else
                    isRefueling = engines[refuelingEngineNum].Refuel(fuelSource);
                if( isRefueling == false)
                {
                    StopRefuel();
                }
            }
        }
    }
    
    private IEnumerator BurningFuel()
    {

        while (true)
        {
            yield return new WaitForSeconds(1f);
            foreach (ShipEngine engine in engines)
            {
                while (engine.fuel != 0 && isRefueling == false)
                {
                    engine.BurningFuel();
                    yield return new WaitForSeconds(1f);
                }
            }
            if (isRefueling == false)
            {
                Debug.Log("Двигатель пуст!");
                isEmpty = true;
            }
            while (isEmpty)
            {
                foreach (ShipEngine engine in engines)
                {
                    if (engine.fuel != 0)
                    {
                        isEmpty = false;
                        Debug.Log("Найден заправленный двигатель");
                        break;
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }

    private Transform ChooseTarget()
    {
        CalculateFuelLevel();
        if (fuelLevel.Min() > 4 / 5)
        {
            refuelingEngineType = "oilStorage";
            return ChooseTargetByDistance(oilFields);
        }
        refuelingEngineNum = fuelLevel.IndexOf(fuelLevel.Min());
        refuelingEngineType = engines[refuelingEngineNum].type;

        if (refuelingEngineType == "oil")
            return ChooseTargetByDistance(oilFields);
        else if (refuelingEngineType == "nuclear")
            return ChooseTargetByDistance(spaceStations);
        else if (refuelingEngineType == "solar")
            return ChooseTargetByDistance(stars);

        Debug.Log("Цель не найдена");
        return null;
    }

    private Transform ChooseTargetByDistance(List<GameObject> fuelSources)
    {
        float distance = Mathf.Infinity;
        Vector3 position = shipTransform.position;
        foreach (GameObject source in fuelSources)
        {
            Vector3 diff = source.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                target = source.transform;
                distance = curDistance;
            }
        }
        return target;
    }

    private IEnumerator GetFuelSources()
    {
        yield return new WaitForSeconds(0.1f);
        oilFields = GameManager.GetComponent<mars>().marsList;
        stars = GameManager.GetComponent<star>().starList;
        spaceStations = GameManager.GetComponent<green>().greenList;

    }
    private void CalculateFuelLevel()
    {
        fuelLevel = new List<float>();
        foreach (ShipEngine engine in engines)
        {
            fuelLevel.Add(engine.fuel / engine.capacity);
        }
    }
}

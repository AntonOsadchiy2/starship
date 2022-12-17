using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] public string type;
    [SerializeField] public int fuel; //������� ���������� � ���������
    [SerializeField] public int capacity; //����������� ���������
    [SerializeField] private int consumption; //����� ������������� ������� � �������
    [SerializeField] private int storageAmount; //������������� ������ �������
    [SerializeField] private int storageCapacity; //����� ������ �������
    private int consumptionSave;
    [SerializeField] private int refuelSpeed; //����� ��������������� ������� � �������
    [SerializeField] private GameObject PanelUI;
    [SerializeField] private TextMeshProUGUI fuelAmountUI;

    void Start()
    {
        fuelAmountUI = PanelUI.GetComponent<TextMeshProUGUI>();
        fuelAmountUI.text = "" + fuel;
        consumptionSave = consumption;
    }

    public void BurningFuel()
    {
        if (fuel > consumption)
            fuel -= consumption;
        else
            fuel = 0;
        fuelAmountUI.text = "" + fuel;
    }


    public bool Refuel(Fuel fuelSource)
    {
        consumption = 0;
        if (fuelSource == null)
        {
            TurnOnEngine();
            return false;
        }
        else if (fuel < capacity)
        {
            fuel += fuelSource.GetSome((int)(refuelSpeed * Time.deltaTime));
            fuelAmountUI.text = "" + fuel;
            return true;
        }
        else if (fuel >= capacity)
        {
            Debug.Log("��������� �����");
            fuel = capacity;
            fuelAmountUI.text = "" + fuel;
            TurnOnEngine();
            return false;
        }
        return false;
    }
    public void TurnOnEngine()
    {
        consumption = consumptionSave;
    }
}

    


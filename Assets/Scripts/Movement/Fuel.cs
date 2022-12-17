using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public int amount;
    public string type;
    [SerializeField] private int solarPower;

    public int GetSome(int n){
        if(type == "solar"){
            return solarPower;
        }
        else if (amount > n)
        {
            amount -= n;
            return n;
        }
        else if (amount <= n)
        {
            int temp = amount;
            amount = 0;
            return temp;
        }
        else return 0;
    }
    void Update()
    {
        if (amount == 0 && type != "solar")
            Destroy(this);
    }
 }

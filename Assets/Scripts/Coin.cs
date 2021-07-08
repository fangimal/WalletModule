using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    
    public Image CoinImage = null;
    public int coinIndexInArray;
    public float coinCount = 0f;

    private string name;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
    public int CoinIndexInArray
    {
        get
        {
            return coinIndexInArray;
        }

        set
        {
            if (value >=0)
            {
                coinIndexInArray = value;
            }
            else
                Debug.LogError("CoinIndexInArray is negative!");
        }
    }
}

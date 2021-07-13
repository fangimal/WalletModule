using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[Serializable]
public class Coin : MonoBehaviour
{
    public Text coinCountText;
    public Image CoinImage = null;
    public int coinIndexInArray;
    public float coinCount = 0f;

    [SerializeField]    private string name;
    SaveSystem saveSystem;
    private void Awake()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
    }
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
    public float CoinCount
    {
        get
        {
            return saveSystem.Load(Name, coinIndexInArray);
        }
        set
        {
            if (value >= 0)
            {
                saveSystem.Save(Name, value, coinIndexInArray);
            }
            else
            {
                Debug.LogError("Coin is negative!");
            }
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
    public void SetCoinCount(float _coinCount)
    {
        CoinCount += _coinCount;
        coinCountText.text = "Count: " + CoinCount.ToString();
    }

    public void SetZeroCoin()
    {
        CoinCount = 0;
        Debug.Log("Сброс значения монеты");
        coinCountText.text = "Count: " + CoinCount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinCountText;
    public Image CoinImage = null;
    public int coinIndexInArray;
    public float coinCount = 0f;

    [SerializeField]    private string name;

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
            return PlayerPrefs.GetFloat(Name);
        }
        set
        {
            if (value >= 0)
            {
                PlayerPrefs.SetFloat(Name, value);
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
        Debug.Log($"Попытка добавить монету.");
        CoinCount += _coinCount;
        coinCountText.text = "Count: " + CoinCount.ToString();
    }

    public void SetZeroCoin()
    {
        CoinCount = 0;
        Debug.Log("Сброс значениz монеты");
        coinCountText.text = "Count: " + CoinCount.ToString();
    }
}

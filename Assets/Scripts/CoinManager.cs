using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    Text coinCoint;
    void Start()
    {
        coinCoint.text = "10";
    }

    
    void Update()
    {
        
    }

    public void IncreaseCoin()
    {
        Debug.Log("Попытка добавить монету.");
    }

    public void ResetCoin()
    {
        Debug.Log("Сброс значений");
    }

}

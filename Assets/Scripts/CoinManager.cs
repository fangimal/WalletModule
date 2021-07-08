using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    Text coinCointText;

    private float coinCount = 0;

    

    [HideInInspector]
    public float CoinCount
    {
        get
        {
            return PlayerPrefs.GetFloat("coinCount");
        }
        set
        {
            if (value >= 0)
            {
                PlayerPrefs.SetFloat("coinCount", value);
            }
            else
            {
                Debug.LogError("gold is negative!");
            }
        }
    }

    void Start()
    {

        coinCointText.text = CoinCount.ToString();
    }


    void Update()
    {
        
    }

    public void IncreaseCoin()
    {
        Debug.Log($"Попытка добавить монету.");
        CoinCount++;
        coinCointText.text = CoinCount.ToString();
    }

    public void ResetCoin()
    {
        CoinCount = 0;
        Debug.Log("Сброс значений");
        coinCointText.text = CoinCount.ToString();
    }

}

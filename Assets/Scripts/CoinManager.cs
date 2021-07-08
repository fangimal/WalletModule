using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    Text coinCointText;

    public Sprite[] CoinSprites;

    public Coin[] CoinArrayWithProperties;

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
        if (CoinSprites.Length > 0)
        {
            Coin[] CoinArrayWithProperties = new Coin[CoinSprites.Length];
            Debug.Log("Good! CoinArrayWithProperties " + CoinArrayWithProperties.Length);
            for (int i = 0; i < CoinArrayWithProperties.Length; i++)
            {

                //Нужно создать экземпляры Coin с заполненными полями и добавить их в Coin Grid

                //CoinArrayWithProperties[i] = Coin.
            }

        }
        else
            Debug.Log("You need to add coin sprites to the array in CoinManager!");
            

        coinCointText.text = "Count: " + CoinCount.ToString();
    }


    void Update()
    {
        
    }

    public void IncreaseCoin(float numberOfCoins)
    {
        Debug.Log($"Попытка добавить монету.");
        CoinCount  += numberOfCoins;
        coinCointText.text = "Count: " + CoinCount.ToString();
    }

    public void ResetCoin()
    {
        CoinCount = 0;
        Debug.Log("Сброс значений");
        coinCointText.text = "Count: " + CoinCount.ToString();
    }

}

/*
 *  + 1. Массив спрайтов. Загружаем массив спрайтов, у каждого спрайта своё уникальное имя
 * 
 *  + 2. Создаём класс Coin который имеет поля: 
 *      - имя; 
 *      - количество монет; 
 *      - спрайт для загрузки картинки;
 *      - индекс, для определения порядка в массиве.
 *      
 * 3. Массив Монет со свойствами. Создаём массив элементов Coin с длиной равной длине массива спрайт п.1
 * 
 * 4. При старте игры заполняем Coin Grid нашими монетами Coin согласно п. 3
 */

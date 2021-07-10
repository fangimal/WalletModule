using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    Text coinCointText;

    public Sprite[] CoinSprites;

    public Coin[] CoinArrayWithProperties;

    [SerializeField] Transform parentCoin;
    [SerializeField] Coin prefabCoin;


    [HideInInspector]
   

    void Start()
    {
        if (CoinSprites.Length > 0)
        {
            Coin[] CoinArrayWithProperties = new Coin[CoinSprites.Length];
            Debug.Log("Good! CoinArrayWithProperties " + CoinArrayWithProperties.Length);
            for (int i = 0; i < CoinArrayWithProperties.Length; i++)
            {
                //Нужно создать экземпляры Coin с заполненными полями и добавить их в Coin Grid
                Coin coin = Instantiate(prefabCoin);
                coin.transform.SetParent(parentCoin);
                coin.transform.localScale= new Vector2(1f, 1f);

                //Заполняем поля Экземпляров Coin считав данные со спрайтов из массива CoinSprites
                coin.CoinImage.sprite = CoinSprites[i];
                coin.coinIndexInArray = i;
                coin.Name = CoinSprites[i].name;
                coin.coinCountText.text = "Count: " + coin.CoinCount.ToString();
            }

        }
        else
            Debug.Log("You need to add coin sprites to the array in CoinManager!");
            
    }


    void Update()
    {
        
    }

    //public void SetCoinCount(float coinCount, Coin coin)
    //{
    //    Debug.Log($"Попытка добавить монету.");
    //    coin.coinCount += coinCount;
    //    coin.coinCointText.text = "Count: " + coin.CoinCount.ToString();
    //}

    //public void SetZeroCoin(Coin coin)
    //{
    //    coin.CoinCount = 0;
    //    Debug.Log("Сброс значениz монеты");
    //    coinCointText.text = "Count: " + coin.CoinCount.ToString();
    //}

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

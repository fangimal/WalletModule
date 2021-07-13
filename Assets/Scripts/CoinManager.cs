using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    [Header("Set Sprites")]
    public Sprite[] CoinSprites;

    [HideInInspector]
    public Coin[] CoinArrayWithProperties;

    [SerializeField] Transform parentCoin;
    [SerializeField] Coin prefabCoin;

    SaveSystem saveSystem;

    void Start()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
        if (CoinSprites.Length > 0)
        {
            Coin[] CoinArrayWithProperties = new Coin[CoinSprites.Length];
            Debug.Log("Good! CoinArrayWithProperties " + CoinArrayWithProperties.Length);
            for (int i = 0; i < CoinArrayWithProperties.Length; i++)
            {
                //Нужно создать экземпляры Coin с заполненными полями и добавить их в Coin Grid
                Coin coin = Instantiate(prefabCoin);
                coin.transform.SetParent(parentCoin);
                coin.transform.localScale = new Vector2(1f, 1f);

                //Заполняем поля Экземпляров Coin считав данные со спрайтов из массива CoinSprites
                coin.CoinImage.sprite = CoinSprites[i];
                coin.coinIndexInArray = i;
                coin.Name = CoinSprites[i].name;
                coin.coinCountText.text = "Count: " + coin.CoinCount.ToString();
            }

            saveSystem.GenerateGameData();
        }
        else
            Debug.Log("You need to add coin sprites to the array in CoinManager!");

    }
}


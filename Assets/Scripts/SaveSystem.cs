using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    CoinManager coinManager;
    public enum SaveMethod
    {
        playerPref,
        binary,
        json
    }
    public SaveMethod saveMethod;

    [Header("Settings")]
    [SerializeField] private string saveFilename;
    [SerializeField] private string pathToSaveFile;
    [SerializeField] private CoinDataList coinDataList;

    bool fileCreateAndSave = false;
    private void Awake()
    {
        pathToSaveFile = Path.Combine(Application.dataPath, saveFilename);

        if (saveMethod == SaveMethod.binary && File.Exists(pathToSaveFile))
        {
            coinDataList = BinarySerializer.Deserialize<CoinDataList>(pathToSaveFile);
            fileCreateAndSave = true;
        }
        else if (saveMethod == SaveMethod.json && File.Exists(pathToSaveFile))
        {
            coinDataList = JsonUtility.FromJson<CoinDataList>(File.ReadAllText(pathToSaveFile));
            fileCreateAndSave = true;
        }
    }
    private void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }
    private void OnApplicationQuit()
    {
        if (saveMethod == SaveMethod.binary)
        {
            BinarySerializer.Serialize(pathToSaveFile, coinDataList);
        }
        else if (saveMethod == SaveMethod.json)
        {
            string strOutput = JsonUtility.ToJson(coinDataList);
            File.WriteAllText(pathToSaveFile, strOutput);
        }
    }
    public void GenerateGameData()
    {
        if (fileCreateAndSave)
        {
            return;
        }
        int coinsCount = coinManager.CoinSprites.Length;
        coinDataList.coinData = new List<CoinData>(); 
        
        for (int i = 0; i < coinsCount; i++)
        {
            coinDataList.coinData.Add(new CoinData
            {
                name = coinManager.CoinSprites[i].name,
                coinCount = 0
            });
        }
    }

    public void Save(string name, float value, int index)
    {
        if (saveMethod == SaveMethod.binary || saveMethod == SaveMethod.json)
        {
            coinDataList.coinData[index].coinCount = value;
        }
        else if (saveMethod == SaveMethod.playerPref)
            PlayerPrefs.SetFloat(name, value);
    }
    public float Load(string name, int index)
    {
        if (saveMethod == SaveMethod.binary || saveMethod == SaveMethod.json)
        {
            return coinDataList.coinData[index].coinCount;
        }

        return PlayerPrefs.HasKey(name) ? PlayerPrefs.GetFloat(name) : 0; 
    }
}

//binary
[Serializable]
public class CoinData
{
    public string name;
    public float coinCount;
}

[Serializable]
public class CoinDataList
{
    public List<CoinData> coinData;
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class DataManager : Singleton<DataManager>
{
    public PlayerData PlayerData = new PlayerData();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SaveData();
        LoadData();
    }
    public void LoadData()
    {
        PlayerData.gold = PlayerPrefs.GetInt("PlayerGold");
        PlayerData.gem = PlayerPrefs.GetInt("PlayerGem");
        Debug.Log("Gold:" + PlayerData.gold + "Gem: " + PlayerData.gem);
    }
    public void SaveData()
    {
        PlayerPrefs.SetInt("PlayerGold", PlayerData.gold);
        Debug.Log("Save Gold: " + PlayerData.gold);
        PlayerPrefs.SetInt("PlayerGem", PlayerData.gem);
        Debug.Log("Save Gem: " + PlayerData.gem);

    }


}

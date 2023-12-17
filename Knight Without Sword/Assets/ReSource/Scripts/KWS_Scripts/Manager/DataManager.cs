using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public PlayerData PlayerData = new PlayerData();

    private void Start()
    {
        SaveData(PlayerData.gold, PlayerData.gem);
    }
    public void LoadData(int gold, int gem)
    {
        gold = PlayerPrefs.GetInt("PlayerGold");
        gem = PlayerPrefs.GetInt("PlayerGem");
        Debug.Log(gold + "" + gem);
    }
    public void SaveData(int gold, int gem)
    {
        PlayerPrefs.SetInt("PlayerGold", gold);
        Debug.Log("Save" + PlayerData.gold);
        PlayerPrefs.SetInt("PlayerGem", gem);
    }
}

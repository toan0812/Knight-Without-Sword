using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataField : Singleton<DataField>
{
    [Header("UI")]
    [SerializeField] private Text goldText;
    private int goldIndex;
    [SerializeField] private Text gemText;
    private int gemIndex;
    void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerGold") && !PlayerPrefs.HasKey("PlayerGem"))
        {
            goldIndex = 0;
            gemIndex = 0;
        }
        else
        {
            LoadData();

        }

    }
    private void LoadDataOnField()
    {
        goldText.text = DataManager.Instance.PlayerData.gold.ToString();
        gemText.text = DataManager.Instance.PlayerData.gem.ToString();
    }

    public void LoadData()
    {
        DataManager.Instance.PlayerData.gold = PlayerPrefs.GetInt("PlayerGold");
        DataManager.Instance.PlayerData.gem = PlayerPrefs.GetInt("PlayerGem");
        LoadDataOnField();
    }
}

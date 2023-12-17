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
        goldText.text = goldIndex.ToString();
        gemText.text = gemIndex.ToString();
    }

    public void LoadData()
    {
        goldIndex = PlayerPrefs.GetInt("PlayerGold");
        gemIndex = PlayerPrefs.GetInt("PlayerGem");
        LoadDataOnField();
    }
}

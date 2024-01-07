using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeaderUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI gemText;
    [SerializeField] TextMeshProUGUI pistolammoText;
    [SerializeField] TextMeshProUGUI plasmaText;
    [SerializeField] TextMeshProUGUI rocketText;
    [SerializeField] TextMeshProUGUI shotgunText;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("PlayerGold") && !PlayerPrefs.HasKey("PlayerGem"))
        {
            DataManager.Instance.PlayerData.gold = 0;
            DataManager.Instance.PlayerData.gem = 0;
        }
        else
        {
            DataManager.Instance.LoadData();
            UIManager.Instance.HeaderUI.UpdateGoldText(DataManager.Instance.PlayerData.gold);
            UIManager.Instance.HeaderUI.UpdateGemText(DataManager.Instance.PlayerData.gem);
        }
    }
    public void UpdateGoldText(int count)
    {
        goldText.text = count.ToString();
    }  
    public void UpdateGemText(int count)
    {
        gemText.text = count.ToString();
    }
    public void UpdatePistolammoText(int count)
    {
        pistolammoText.text = count.ToString();
    } 
    public void UpdateplasmaText(int count)
    {
        plasmaText.text = count.ToString();
    }
    public void UpdaterocketText(int count)
    {
        rocketText.text = count.ToString();
    }
    public void UpdateshotgunText(int count)
    {
        shotgunText.text = count.ToString();
    }

    public void ReloadHeaderUI(EquidmentsSO equidmentsSO)
    {
        if(equidmentsSO.prefabName == "plasmaAmmo")
        {
            UpdateplasmaText(DataManager.Instance.PlayerData.plasmaAmmo.quatity);
        } 
        if(equidmentsSO.prefabName == "pistolAmmo")
        {
            UpdatePistolammoText(DataManager.Instance.PlayerData.pistolAmmo.quatity);
        } 
        if(equidmentsSO.prefabName == "rocketAmmo")
        {
            UpdaterocketText(DataManager.Instance.PlayerData.rocketAmmo.quatity);
        } 
        if(equidmentsSO.prefabName == "shotgunAmmo")
        {
            UpdateshotgunText(DataManager.Instance.PlayerData.shotgunAmmo.quatity);
        }
    }

}

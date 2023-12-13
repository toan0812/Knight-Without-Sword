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
        UpdateGemText(DataManager.Instance.PlayerData.gem);
        UpdateGoldText(DataManager.Instance.PlayerData.gold);
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

}

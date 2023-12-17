using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuyCharacterUI : MonoBehaviour
{
    [Header("PlayerSO")]
    [SerializeField] private PlayerSO playerSO;
    private bool canBuyItem;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            BuyItemByGem((int)playerSO.price);
        });
    }
    public void BuyItemByGem(int price)
    {
        canBuyItem = DataManager.Instance.PlayerData.gem >= price? true : false;
        if (DataManager.Instance.PlayerData.gem >= price)
        {
            DataManager.Instance.PlayerData.gem -= price;
            DataManager.Instance.SaveData(DataManager.Instance.PlayerData.gold, DataManager.Instance.PlayerData.gem);
            DataField.Instance.LoadData();
        }
        else
        {
            Debug.Log("can not buy item");
        }
    }

    public void SetPlayerSO(PlayerSO playerSO)
    {
        this.playerSO = playerSO;
    }
    public bool CanBuyItem()
    {
        return canBuyItem;
    }
}

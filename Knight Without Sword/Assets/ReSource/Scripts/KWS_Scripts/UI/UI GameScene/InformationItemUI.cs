using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationItemUI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private ShopUI shopUI;
    [Header("UI")]
    [SerializeField] private Text itemNametext;
    [SerializeField] private Text itemDescriptionText;
    void Start()
    {
        shopUI.OnShowInfor += ShopUI_OnShowInfor; ;
    }

    private void ShopUI_OnShowInfor(object sender, ShopUI.InforItemsEventArg e)
    {
        ShowInfor(e.itemSO);
    }

    private void ShowInfor(ItemSO itemSO)
    {
        itemNametext.text = itemSO.prefabName;
        itemDescriptionText.text = itemSO.description;
    }
}

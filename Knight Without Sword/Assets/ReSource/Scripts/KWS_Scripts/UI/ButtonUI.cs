using UnityEngine;
using UnityEngine.UI;
using System;
public class ButtonUI : MonoBehaviour
{
    [Header("Change Color")]
    [SerializeField] bool isChangingColor;
    [SerializeField] ShopUI shopUI;
    [Header("ItemSO")]
    [SerializeField] EquidmentsSO equidmentsSO;
    [SerializeField] WeaponItemsSO weaponItemsSO;
    [Header("Text")]
    [SerializeField] private Text buyGoldText;
    [SerializeField] private Text buyGemText;   
    [Header("Buttons")]
    [SerializeField] private Button buyGoldButton;
    [SerializeField] private Button buyGemButton;

    private PlayerData playerData= new PlayerData();
    void Start()
    {
        shopUI = GameObject.FindAnyObjectByType<ShopUI>();
        if (isChangingColor)
        {
            GetComponent<Button>().Select();
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shopUI.ShowInforButtonUI();
        });
        buyGoldButton.onClick.AddListener(() =>
        {
            BuyItem(playerData.gold, Int32.Parse(buyGoldText.text));
        });
        buyGemButton.onClick.AddListener(() =>
        {
            BuyItem(playerData.gem, Int32.Parse(buyGemText.text));
        });

    }

    public void BuyItem(int budget, int price)
    {
        if(budget>=price)
        {
            budget -= price;
        }
       else
        {
            Debug.Log("can not buy item");
        }
    }
    public void SetPriceTextForItem()
    {
        if(equidmentsSO!= null)
        {
            buyGoldText.text = equidmentsSO.goldPrice.ToString();
            buyGemText.text = equidmentsSO.gemPrice.ToString();
        }
        if(weaponItemsSO != null)
        {
            buyGoldText.text = weaponItemsSO.goldPrice.ToString();
            buyGemText.text = weaponItemsSO.gemPrice.ToString();
        }
    }
    public void SetEquidmentsSO(EquidmentsSO equidmentsSO)
    {
        this.equidmentsSO = equidmentsSO;
    } 
    public void SetWeaponSO(WeaponItemsSO weaponItemsSO)
    {
        this.weaponItemsSO = weaponItemsSO;
    }
}

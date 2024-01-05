using UnityEngine;
using UnityEngine.UI;
using System;
public class ButtonUI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private HeaderUI headerUI;
    [SerializeField] private GetItems getItems;
    [SerializeField] private ItemsSupUI itemsSupUI;
    [Header("Change Color")]
    [SerializeField] bool isChangingColor;
    [SerializeField] ShopUI shopUI;
    [Header("ItemSO")]
    [SerializeField] EquidmentsSO equidmentsSO;
    [SerializeField] WeaponItemsSO weaponItemsSO;
    [SerializeField] ItemsSupSO itemsSupSO;
    [Header("Text")]
    [SerializeField] private Text buyGoldText;
    [SerializeField] private Text buyGemText;   
    [Header("Buttons")]
    [SerializeField] private Button buyGoldButton;
    [SerializeField] private Button buyGemButton;
    [SerializeField] private Transform spawnPos;
    void Start()
    {
        shopUI = GameObject.FindAnyObjectByType<ShopUI>();
        headerUI = GameObject.FindAnyObjectByType<HeaderUI>();
        getItems = GameObject.FindAnyObjectByType<GetItems>();
        spawnPos = GameObject.Find("pos").transform;
        if (isChangingColor)
        {
            GetComponent<Button>().Select();
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shopUI.ShowInforButtonUI(GetItemSO());
        });
        buyGoldButton.onClick.AddListener(() =>
        {
            BuyItemByGold(Int32.Parse(buyGoldText.text));
            headerUI.UpdateGoldText(DataManager.Instance.PlayerData.gold);
        });
        buyGemButton.onClick.AddListener(() =>
        {
            BuyItemByGem(Int32.Parse(buyGemText.text));
            headerUI.UpdateGemText(DataManager.Instance.PlayerData.gem);
        });

    }

    public void BuyItemByGold(int price)
    {
        if(DataManager.Instance.PlayerData.gold >=price)
        {
            DataManager.Instance.PlayerData.gold -= price;
            UpdateDB();
        }
       else
        {
            Debug.Log("can not buy item");
        }
    }
    public void BuyItemByGem(int price)
    {
        if(DataManager.Instance.PlayerData.gem >=price )
        {
            DataManager.Instance.PlayerData.gem -= price;
            UpdateDB();
        }
       else
        {
            Debug.Log("can not buy item");
        }
    }

    public void UpdateDB()
    {
        if (equidmentsSO != null)
        {
            getItems.AddItems(equidmentsSO);
        }
        if (weaponItemsSO != null)
        {
            var weapon = Instantiate(weaponItemsSO.prefab);
            weapon.position = spawnPos.position;
        }
        if (itemsSupSO != null)
        {
            itemsSupUI.SpawnIcon(itemsSupSO);
            if(itemsSupUI.CheckItemInList(itemsSupSO))
            {
                buyGoldButton.enabled = false;
                buyGemButton.enabled = false;
            }
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
        if(itemsSupSO != null)
        {
            buyGoldText.text = itemsSupSO.goldPrice.ToString();
            buyGemText.text = itemsSupSO.gemPrice.ToString();
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
    public void SetItemSupSO(ItemsSupSO itemsSupSO)
    {
        this.itemsSupSO = itemsSupSO;
    }
    public ItemSO GetItemSO()
    {
        if (equidmentsSO != null)
        {
          return equidmentsSO;
        }
        if (weaponItemsSO != null)
        {
            return weaponItemsSO;
        }
        if (itemsSupSO != null)
        {
            return itemsSupSO;
        }
        return null;
    }
}

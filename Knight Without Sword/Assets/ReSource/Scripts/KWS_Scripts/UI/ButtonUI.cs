using UnityEngine;
using UnityEngine.UI;
using System;
public class ButtonUI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private HeaderUI headerUI;
    [SerializeField] private GetItems getItems;
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

    void Start()
    {
        shopUI = GameObject.FindAnyObjectByType<ShopUI>();
        headerUI = GameObject.FindAnyObjectByType<HeaderUI>();
        getItems = GameObject.FindAnyObjectByType<GetItems>();
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
        if(DataManager.Instance.PlayerData.gem >=price)
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
            Vector2 randomPoint = UnityEngine.Random.insideUnitCircle * 2f;
            Vector3 randomPosition = new Vector3(randomPoint.x, 0, randomPoint.y);
            weapon.position = Player.Instance.transform.position + randomPosition;
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

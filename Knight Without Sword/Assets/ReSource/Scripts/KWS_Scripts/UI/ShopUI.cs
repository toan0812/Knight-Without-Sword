using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
public class ShopUI : MonoBehaviour
{
    public class InforItemsEventArg : EventArgs
    {
        public ItemSO itemSO;
    }

    public event EventHandler<InforItemsEventArg> OnShowInfor;
    [Header("Shop Holder")]
    [SerializeField] private GameObject shopHolder;
    [SerializeField] private GameObject inforItems;
    [SerializeField] private float shopPos;
    [SerializeField] private float inforItemPos;
    [SerializeField] private float inforItemPosStart;
    [SerializeField] private float shopPosStart;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Vector2 shopPosForinfor = new Vector2(-10, 130);
    [Header("UI Items")]
    [SerializeField] private GameObject supItemsUI;
    [SerializeField] private GameObject supItemsViewPort;
    [SerializeField] private GameObject gunItemsUI;
    [SerializeField] private GameObject gunItemsViewPort;
    [SerializeField] private GameObject equidmentItemsUI;
    [SerializeField] private GameObject equidmentItemsViewPort;
    [Header("UI Scroll view")]
    [SerializeField] private GameObject supScrollView;
    [SerializeField] private GameObject gunScrollView;
    [SerializeField] private GameObject equidmentScrollView;
    [Header("Button")]
    [SerializeField] private Button supButton;
    private int timeSpawnSupButton = 1;
    [SerializeField] private Button gunButton;
    private int timeSpawngunButton = 1;
    [SerializeField] private Button EquidmentButton;
    private int timeSpawnEquidmentButton = 1;
    private List<GameObject> holder = new List<GameObject>();
    private void Start()
    {
        supItemsUI.SetActive(false);
        gunItemsUI.SetActive(false);
        equidmentItemsUI.SetActive(false);
        gunScrollView.SetActive(false);
        equidmentScrollView.SetActive(false);

        supButton.onClick.AddListener(() =>
        {
            Debug.Log("supBut Onclick");
        });
        gunButton.onClick.AddListener(() =>
        {
            GetGunItemsFromDB();
        });
        EquidmentButton.onClick.AddListener(() =>
        {
            GetEquidmentsItemsFromDB();
        });
    }
    public void ActiveHolder()
    {
        Time.timeScale = 0;
        shopHolder.transform.DOLocalMoveY(shopPos, duration).SetUpdate(true);
    }

    public void DeActiveHolder()
    {
        inforItems.transform.DOLocalMoveX(inforItemPosStart, duration).SetUpdate(true);
        shopHolder.transform.DOLocalMoveY(shopPosStart, duration).SetUpdate(true).IsComplete();
        Time.timeScale = 1;
    }
    public void ShowInforButtonUI(ItemSO itemSO)
    {
        shopHolder.transform.DOLocalMoveX(shopPosForinfor.x, duration).SetUpdate(true);
        OnShowInfor?.Invoke(this, new InforItemsEventArg { itemSO = itemSO});
        inforItems.transform.DOLocalMoveX(inforItemPos, duration).SetUpdate(true);
    }
    public void HideInforButton()
    {
        inforItems.transform.DOLocalMoveX(inforItemPosStart, duration).SetUpdate(true);
        shopHolder.transform.DOLocalMoveX(shopPos, duration).SetUpdate(true);
    }

    public void GetGunItemsFromDB()
    {
        gunScrollView.SetActive(true);
        supScrollView.SetActive(false);
        equidmentScrollView.SetActive(false);
        if(timeSpawngunButton > 0)
        {
            for (int i = 0; i < WeaponManager.Instance.GetWeaponItemsFromDB().Count; i++)
            {
                var gunItemUI = Instantiate(gunItemsUI, gunItemsViewPort.transform);
                gunItemUI.transform.GetChild(0).GetComponent<Image>().sprite = WeaponManager.Instance.GetWeaponItemsFromDB()[i].prefabImage;
                gunItemUI.GetComponent<ButtonUI>().SetWeaponSO(WeaponManager.Instance.GetWeaponItemsFromDB()[i]);
                gunItemUI.GetComponent<ButtonUI>().SetPriceTextForItem();
                gunItemUI.SetActive(true);
                holder.Add(gunItemUI);
            }
            timeSpawngunButton--;
        }
       
    } 
    public void GetEquidmentsItemsFromDB()
    {
        gunScrollView.SetActive(false);
        supScrollView.SetActive(false);
        equidmentScrollView.SetActive(true);
        if(timeSpawnEquidmentButton > 0)
        {
            for (int i = 0; i < ItemsManager.Instance.GetEquidItemsFromDB().Count; i++)
            {
                var ItemUI = Instantiate(equidmentItemsUI, equidmentItemsViewPort.transform);
                ItemUI.transform.GetChild(0).GetComponent<Image>().sprite = ItemsManager.Instance.GetEquidItemsFromDB()[i].prefabImage;
                ItemUI.GetComponent<ButtonUI>().SetEquidmentsSO(ItemsManager.Instance.GetEquidItemsFromDB()[i]);
                ItemUI.GetComponent<ButtonUI>().SetPriceTextForItem();
                ItemUI.SetActive(true);
            }
            timeSpawnEquidmentButton--;
        }
        
    }

}

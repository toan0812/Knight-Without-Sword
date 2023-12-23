using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEditor.Progress;

public class GiftBoxUI : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private UIGift UIGift;
    [Header("UI")]
    [SerializeField] private Button claimBtn;
    [Header("Prefabs")]
    [SerializeField] private Transform container;
    [SerializeField] private Transform giftField;
    [SerializeField] private GameObject gift;
    private int quatityGift = 2;
    [Header("DOMove")]
    [SerializeField] private Transform endPos;
    [SerializeField] private Ease ease;
    [SerializeField] float timeDuration;
    [Header("Recivable")]
    [SerializeField] private List<Gift> itemSOs = new List<Gift>();

    private void OnDisable()
    {
        ClearList();
        itemSOs.Clear();
        claimBtn.gameObject.SetActive(false);
    }
    void OnEnable()
    {

        giftField.transform.DOMove(endPos.position, timeDuration).SetEase(ease).OnComplete(() => {
            StartCoroutine(SpawnGift(quatityGift));
        });
        claimBtn.onClick.AddListener(() => {

            ClaimItems();
            DataField.Instance.LoadData();
            UIGift.ResetTime();
            gameObject.SetActive(false);
        });
    }
    
    IEnumerator SpawnGift(int quatityGift)
    {
        while(quatityGift>0)
        {
            yield return new WaitForSeconds(0.5f);
            var giftbox = Instantiate(gift, container);
            giftbox.SetActive(true);
            itemSOs.Add(giftbox.GetComponent<Gift>());
            quatityGift--;
        }
        claimBtn.gameObject.SetActive(true);
    }
    public void ClaimItems()
    {
        foreach(var item in itemSOs)
        {
            if (item.GetItemSO().type == ItemsType.trading && item.GetItemSO().prefabName == "Gold")
            {
                DataManager.Instance.PlayerData.gold += item.GetItemSO().count;
                DataManager.Instance.SaveData();
            }
            if (item.GetItemSO().type == ItemsType.trading && item.GetItemSO().prefabName == "Gem")
            {
                DataManager.Instance.PlayerData.gem += item.GetItemSO().count;
                DataManager.Instance.SaveData();
            }
        }
    }

    private void ClearList()
    {
        for (int i = 0; i < itemSOs.Count; i++)
        {
            itemSOs[i].OnDestroy();
        }
    }
}

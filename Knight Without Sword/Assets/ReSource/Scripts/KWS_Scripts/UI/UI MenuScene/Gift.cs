using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Gift : MonoBehaviour
{
    private GetItems getItems;
    [SerializeField] ItemSO itemSO;
    [SerializeField] private Ease ease;
    [Header("UI")]
    [SerializeField] private Image image;
    public ItemSO GetItemSO()
    {
        return itemSO;
    }

    private void OnEnable()
    {
        getItems = GameObject.FindAnyObjectByType<GetItems>();
        if (getItems == null)
        {
            SetItemSOForGift(CollectableSpawmManager.Instance.Spawn().GetComponent<ItemsPickUp>().GetItemSO());
        }
        if (getItems != null)
        {
            SetItemSOForGift(getItems.GetSpecialItemSO(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO()));
        }
        image.sprite = itemSO.prefabImage;
    }
    void Start()
    {
        gameObject.transform.DOScale(1,1).SetEase(ease);
    }

    public void SetItemSOForGift(ItemSO itemSO)
    {
        this.itemSO = itemSO;
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
        Debug.Log("destroy");
    }
}

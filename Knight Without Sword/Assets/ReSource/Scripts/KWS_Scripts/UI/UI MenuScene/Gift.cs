using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Gift : MonoBehaviour
{
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
        itemSO = CollectableSpawmManager.Instance.Spawn().GetComponent<ItemsPickUp>().GetItemSO();
        image.sprite = itemSO.prefabImage;
    }
    void Start()
    {
        gameObject.transform.DOScale(1,1).SetEase(ease);
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
        Debug.Log("destroy");
    }
}

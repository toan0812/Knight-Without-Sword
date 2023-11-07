using UnityEngine;
using DG.Tweening;
public class ShopUI : MonoBehaviour
{
    [Header("Shop Holder")]
    [SerializeField] private GameObject shopHolder;
    [SerializeField] private GameObject inforItems;
    [SerializeField] private float shopPos;
    [SerializeField] private float inforItemPos;
    [SerializeField] private float inforItemPosStart;
    [SerializeField]private float shopPosStart;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Vector2 shopPosForinfor = new Vector2(-10,130);

    public void ActiveHolder()
    {
        Time.timeScale = 0;
        shopHolder.transform.DOLocalMoveY(shopPos, duration).SetUpdate(true);
    }

    public void DeActiveHolder()
    {
        shopHolder.transform.DOLocalMoveY(shopPosStart, duration).SetUpdate(true);
        Time.timeScale = 1;
    }
    public void ShowInforButton()
    {
        shopHolder.transform.DOLocalMoveX(shopPosForinfor.x, duration).SetUpdate(true);
        inforItems.transform.DOLocalMoveX(inforItemPos, duration).SetUpdate(true);
    }
    public void HideInforButton()
    {
        inforItems.transform.DOLocalMoveX(inforItemPosStart, duration).SetUpdate(true);
        shopHolder.transform.DOLocalMoveX(shopPos, duration).SetUpdate(true);
    }

}

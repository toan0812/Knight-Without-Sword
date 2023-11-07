using UnityEngine;
using DG.Tweening;
public class ShopUI : MonoBehaviour
{
    [Header("Shop Holder")]
    [SerializeField] private GameObject shopHolder;
    [SerializeField] private float shopPos;
    [SerializeField] private float shopPosStart;
    [SerializeField] private float duration = 0.5f;
    private void Start()
    {
        shopPosStart = shopHolder.transform.position.y;
        shopHolder.SetActive(false);
        
    }

    public void ActiveHolder()
    {
        shopHolder.SetActive(true);
        Time.timeScale = 0;
        shopHolder.transform.DOLocalMoveY(shopPos, duration).SetUpdate(true);
    }

    public void DeActiveHolder()
    {
        shopHolder.transform.DOLocalMoveY(shopPosStart, duration).SetUpdate(true);
        shopHolder.SetActive(false);
        Time.timeScale = 1;
    }
}

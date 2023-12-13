using UnityEngine.UI;
using UnityEngine;

public class QuitShopButtonUI : MonoBehaviour
{
    [SerializeField] ShopUI shopUI;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shopUI.DeActiveHolder();
        });
    }
}

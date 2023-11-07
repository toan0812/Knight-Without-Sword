using UnityEngine;
using UnityEngine.UI;
public class ButtonUI : MonoBehaviour
{
    [SerializeField] bool isChangingColor;
    [SerializeField] ShopUI shopUI;
    void Start()
    {
        if (isChangingColor)
        {
            GetComponent<Button>().Select();
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shopUI.ShowInforButton();
        });
    }
}

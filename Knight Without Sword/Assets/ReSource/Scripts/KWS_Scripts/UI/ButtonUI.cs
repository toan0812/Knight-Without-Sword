using UnityEngine;
using UnityEngine.UI;
public class ButtonUI : MonoBehaviour
{
    [SerializeField] bool isChangingColor;
    [SerializeField] ShopUI shopUI;
    [SerializeField] EquidmentsSO equidmentsSO;
    [SerializeField] WeaponItemsSO weaponItemsSO;
    void Start()
    {
        shopUI = GameObject.FindAnyObjectByType<ShopUI>();
        if (isChangingColor)
        {
            GetComponent<Button>().Select();
        }
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shopUI.ShowInforButtonUI();
        });
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

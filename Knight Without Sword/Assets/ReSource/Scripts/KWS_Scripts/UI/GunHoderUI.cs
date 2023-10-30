using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GunHoderUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image gunImage;
    [SerializeField] private Image bulletImage;
    [SerializeField] private TextMeshProUGUI quantityAmmo;
    [Header("Bullet Bar")]
    [SerializeField] private SliderUI sliderUI;
    private int ammoquatity;

    void Start()
    {
        SetUpHolder(Player.Instance.Weapon().ammoQuatity);
        sliderUI.SetSliderMaxValue(Player.Instance.Weapon().ammoQuatity);
        GameInput.Instance.OnInteract += Instance_OnInteract;
    }
    private void Instance_OnInteract(object sender, System.EventArgs e)
    {
        SetUpHolder(Player.Instance.WeaponUsing().GetComponentInChildren<GunShoot>().GetBulletRemain());
    }
    public void SetUpHolder(int ammo)
    {
        gunImage.sprite = Player.Instance.Weapon().prefabImage;
        quantityAmmo.text = ammo.ToString() + "/" + WeaponManager.Instance.GetDataFormDictionary(Player.Instance.Weapon(), ammoquatity).ToString();
        bulletImage.sprite = Player.Instance.Weapon().ammoEquipment.prefabImage;
        sliderUI.SetSliderMaxValue(Player.Instance.Weapon().ammoQuatity);
        sliderUI.SetSliderValue(ammo);
    }
    public void AmmoConsumptionUI(int remainingBullets)
    {
        quantityAmmo.text = remainingBullets.ToString() + "/" + WeaponManager.Instance.GetDataFormDictionary(Player.Instance.Weapon(), ammoquatity).ToString();
        sliderUI.SetSliderValue(remainingBullets);
    }

    public void UpdateAmmoHolder(ItemSO itemSO,int ammo)
    {
        if (Player.Instance.Weapon().ammoEquipment.prefabName== itemSO.prefabName)
        {
            quantityAmmo.text = Player.Instance.WeaponUsing().GetComponentInChildren<GunShoot>().GetBulletRemain() + "/" + ammo.ToString();
        }  
    }
}

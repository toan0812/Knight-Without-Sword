using UnityEngine;
using System.Collections.Generic;
public class GunController : MonoBehaviour
{
    [Header("WeaponItemSO")]
    [SerializeField] private WeaponItemsSO weaponItemsSO;   
    private void Start()
    {
        Player.Instance.OnChangeGun += Instance_OnChangeGun;
    }
    private void Instance_OnChangeGun(object sender, System.EventArgs e)
    {
        if (Player.Instance.Weapon() == weaponItemsSO && Player.Instance.CloseGun())
        {
            GetComponentInChildren<LookatMouse>().enabled = false;
            transform.GetComponentInChildren<GunShoot>().transform.rotation = Quaternion.Euler(Vector3.zero);   
            transform.GetComponentInChildren<GunShoot>().transform.localScale = new Vector3(1,1,1);   
        }
    }
    public WeaponItemsSO GetWeaponItemsSO()
    {
       return weaponItemsSO;
    }

    private void Update()
    {
        CheckOnPlayer();
    }
    public void CheckOnPlayer()
    {
        if(Player.Instance.Weapon() == weaponItemsSO)
        {
            GetComponentInChildren<Collider2D>().enabled = false;
            GetComponentInChildren<GunShoot>().canShoot = true;
            GetComponentInChildren<SelectedGun>().hand.SetActive(true);
        }
        else
        {
            GetComponentInChildren<Collider2D>().enabled = true;
            GetComponentInChildren<GunShoot>().canShoot = false;
            GetComponentInChildren<SelectedGun>().hand.SetActive(false);
        }
    }
}

using UnityEngine;
using System.Collections.Generic;
public class GunController : MonoBehaviour
{
    [Header("WeaponItemSO")]
    [SerializeField] private WeaponItemsSO weaponItemsSO;
    private GunShoot gunShoot;
    private LookatMouse lookatMouse;
    private SelectedGun selectedGun;
    private void Awake()
    {
        gunShoot = GetComponentInChildren<GunShoot>();
        lookatMouse = GetComponentInChildren<LookatMouse>();
        selectedGun = GetComponentInChildren<SelectedGun>();
    }
    private void Start()
    {
        Player.Instance.OnChangeGun += Instance_OnChangeGun;
    }
    private void Instance_OnChangeGun(object sender, System.EventArgs e)
    {
        if (Player.Instance.Weapon() == weaponItemsSO && Player.Instance.CloseGun())
        {
            lookatMouse.enabled = false;
            gunShoot.transform.rotation = Quaternion.Euler(Vector3.zero);
            gunShoot.transform.localScale = new Vector3(1,1,1);   
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
            gunShoot.canShoot = true;
            selectedGun.hand.SetActive(true);
        }
        else
        {
            GetComponentInChildren<Collider2D>().enabled = true;
            gunShoot.canShoot = false;
            selectedGun.hand.SetActive(false);
        }
    }
}

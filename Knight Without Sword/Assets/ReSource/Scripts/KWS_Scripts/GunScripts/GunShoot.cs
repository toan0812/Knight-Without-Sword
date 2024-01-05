using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GunShoot : MonoBehaviour
{
    [SerializeField]protected GunController gunController;
    [Header("Point to Spawn Bullet")]
    [SerializeField] protected Transform shootingPoint;
    [Header("Time To Delay BTW Shoot")]
    [SerializeField] private float timeDelayMax;
    [SerializeField] protected float timeReloadMax;
    [Header("bullet Spread")]
    [SerializeField] protected int numberBullet;
    [Range(0, 360)]
    [SerializeField] private float startAngle, endAngle;
    private float timeDelay;
    protected float timeReload;
    bool reloading;
    private BulletTape bulletTape;
    public bool canShoot = false;
    [Header("Bullets Remaining")]
    protected int bulletsRemain;
    
    private void Awake()
    {
        timeDelayMax = GetComponentInParent<GunController>().GetWeaponItemsSO().timeDelay;
        bulletTape = GetComponent<BulletTape>();
        bulletsRemain = GetComponentInParent<GunController>().GetWeaponItemsSO().ammoQuatity;
    }
    void Start()
    {
        GameInput.Instance.Onshoot += Instance_Onshoot;
        //GameInput.Instance.OnReloading += Instance_OnReloading;
        timeDelay = timeDelayMax;
        timeReload = timeReloadMax;
    }

    private void Instance_OnReloading(object sender, System.EventArgs e)
    {
        ReLoadBullet();
    }

    private void Instance_Onshoot(object sender, System.EventArgs e)
    {
        if(canShoot)
        {
            Shooting();
            //ReLoadBullet();
        }
    }
    private void Update()
    {
        timeDelay -= Time.deltaTime;
        //WeaponManager.Instance.GetDataFormDictionary(GetComponentInParent<GunController>().GetWeaponItemsSO(), bulletsRemain);
        ReLoadBullet();
    }
    void Shooting()
    {
        if (timeDelay <= 0 && bulletsRemain>= numberBullet)
        {
            float angleStep = (endAngle - startAngle) / numberBullet;
            float angle = startAngle;
            GetComponent<AudioSource>().PlayOneShot(GetComponentInParent<GunController>().GetWeaponItemsSO().shootSoundEffect);
            for (int i = 0; i < numberBullet; i++)
            {
                float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
                float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
                Vector3 bulMoveDir = new Vector3(bulDirX, bulDirY, 0f);
                Vector2 bulDir = (bulMoveDir - transform.position).normalized;
                GameObject Bullet = PoolingObject.Instance.GetPoolingobj(bulletTape.bulletTapes);
                Bullet.transform.position = shootingPoint.position;
                Bullet.SetActive(true);
                Bullet.GetComponentInChildren<ClassicBullet>().SetDirection(bulDir);
                angle += angleStep;
                bulletsRemain -= numberBullet;
                UIManager.Instance.GunHoderUI.AmmoConsumptionUI(bulletsRemain);
                timeDelay = timeDelayMax;
            }
        }
    }


    protected void ReLoadBullet()
    {
        if (bulletsRemain < numberBullet)
        {
            StartCoroutine(Player.Instance.LoadingActive(timeReload, gunController.GetWeaponItemsSO()));
            timeReload -= Time.deltaTime;
            if (WeaponManager.Instance.GetDataFormDictionary(gunController.GetWeaponItemsSO(), bulletsRemain) > 0 && timeReload < 0)
            {
                if (WeaponManager.Instance.GetDataFormDictionary(gunController.GetWeaponItemsSO(), bulletsRemain) > gunController.GetWeaponItemsSO().ammoQuatity)
                {
                    bulletsRemain = gunController.GetWeaponItemsSO().ammoQuatity;
                    WeaponManager.Instance.ReducedAmmoInInventory(gunController.GetWeaponItemsSO(), gunController.GetWeaponItemsSO().ammoQuatity);
                    UIManager.Instance.GunHoderUI.AmmoConsumptionUI(bulletsRemain);
                    timeReload = timeReloadMax;
                }
                else if (WeaponManager.Instance.GetDataFormDictionary(gunController.GetWeaponItemsSO(), bulletsRemain) <= gunController.GetWeaponItemsSO().ammoQuatity)
                {
                    bulletsRemain = WeaponManager.Instance.GetDataFormDictionary(gunController.GetWeaponItemsSO(), bulletsRemain);
                    WeaponManager.Instance.ReducedAmmoInInventory(gunController.GetWeaponItemsSO(), bulletsRemain);
                    UIManager.Instance.GunHoderUI.AmmoConsumptionUI(bulletsRemain);
                    timeReload = timeReloadMax;
                }
            }
            else if (WeaponManager.Instance.GetDataFormDictionary(gunController.GetWeaponItemsSO(), bulletsRemain) <= 0 && bulletsRemain <= 0
                && gunController.GetWeaponItemsSO() == Player.Instance.Weapon())
            {
                UIManager.Instance.GunHoderUI.AmmoConsumptionUI(bulletsRemain);
            }
        }

    }

    public int GetBulletRemain()
    {
        return bulletsRemain;
    }
}


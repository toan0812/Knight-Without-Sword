using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LazerGunShoot : GunShoot
{
    [SerializeField] Transform lazerOrigin;
    [SerializeField] LayerMask LayerMask;
    [SerializeField] GameObject endVFX;
    [SerializeField] GameObject startVFX;
    LineRenderer lineRenderer;
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    float timer = 0;
    private void Awake()
    {
        bulletsRemain = gunController.GetWeaponItemsSO().ammoQuatity;
    }
    private void Start()
    {
        FillList();
        lineRenderer = GetComponent<LineRenderer>();
        timeReload = timeReloadMax;
        GameInput.Instance.Onshoot += Instance_Onshoot;
        //GameInput.Instance.OnReloading += Instance_OnReloading;
    }
    private void Instance_OnReloading(object sender, System.EventArgs e)
    {
        ReLoadBullet();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        ReLoadBullet();
        if (Input.GetKeyUp(KeyCode.Mouse0) || bulletsRemain <= 0)
        {
            lineRenderer.enabled = false;
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Stop();
            }
        }
        if(Input.GetButtonDown("Fire1") && canShoot && bulletsRemain > 0)
        {
            SetActiveLazer();
        }

    }
    private void Instance_Onshoot(object sender, System.EventArgs e)
    {
        if (canShoot && bulletsRemain>0)
        {
            LazerShoot();
        }
    }


    private void LazerShoot()
    {
        lineRenderer.SetPosition(0, lazerOrigin.position);
        startVFX.transform.position = lazerOrigin.position;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(shootingPoint.position,transform.right,(int)gunController.GetWeaponItemsSO().range, LayerMask);
        if (raycastHit2D.collider != null)
        {
            lineRenderer.SetPosition(1, raycastHit2D.point);
            if (raycastHit2D.collider.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable = raycastHit2D.collider.GetComponent<IDamageable>();
                if (iDamageable != null && timer <= 0)
                {
                    timer = .25f;
                    bulletsRemain -= numberBullet;
                    UIManager.Instance.GunHoderUI.AmmoConsumptionUI(bulletsRemain);
                    iDamageable.TakeDamage((int)gunController.GetWeaponItemsSO().damage);
                    
                }
            }
        }
        else
        {
            if(timer<=0)
            {
                timer = .25f;
                bulletsRemain -= numberBullet;
                UIManager.Instance.GunHoderUI.AmmoConsumptionUI(bulletsRemain);
            }
            lineRenderer.SetPosition(1, shootingPoint.position+(transform.right * gunController.GetWeaponItemsSO().range));
        }
        endVFX.transform.position = lineRenderer.GetPosition(1);

    }
    void SetActiveLazer()
    {
        
        lineRenderer.enabled = true;
        for(int i =0; i< particles.Count;i++)
        {
            particles[i].Play();
        }
    }

    void FillList()
    {
        for(int i =0;i< startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
            {
                particles.Add(ps);
            }
        }

        for (int i = 0; i < endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }
}

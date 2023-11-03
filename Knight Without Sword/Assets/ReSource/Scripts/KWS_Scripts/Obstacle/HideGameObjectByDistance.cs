using System.Collections;
using UnityEngine;

public class HideGameObjectByDistance : MonoBehaviour
{
    //[Header("Range Attack OF Gun")]
    GunController gunController;
    GunShoot gunShoot;
    private void Start()
    {
        gunController = GetComponentInParent<GunController>();
        gunShoot = gunController.GetComponentInChildren<GunShoot>();
    }
    private void OnEnable()
    {
        //StartCoroutine(SetavtiveObject());
    }

    private void Update()
    {
        SetavtiveObject();
    }
    void SetavtiveObject()
    {
            if (Vector2.Distance(transform.position, gunShoot.transform.position) >= gunController.GetWeaponItemsSO().range)
            {
                gameObject.SetActive(false);
            }


    }

}

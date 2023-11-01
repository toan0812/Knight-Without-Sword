using System.Collections;
using UnityEngine;

public class HideGameObjectByDistance : MonoBehaviour
{
    //[Header("Range Attack OF Gun")]
    [SerializeField] GunController gunController;
    private void Start()
    {
        gunController = GetComponentInParent<GunController>();
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
            if (Vector2.Distance(transform.position, gunController.transform.position) >= gunController.GetWeaponItemsSO().range)
            {
                gameObject.SetActive(false);
            }


    }

}

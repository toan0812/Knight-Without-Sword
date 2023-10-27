using System.Collections;
using UnityEngine;

public class HideGameObjectByDistance : MonoBehaviour
{
    //[Header("Range Attack OF Gun")]
    //[SerializeField] private float time =0.1f;
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
            if (Vector2.Distance(transform.position, GetComponentInParent<GunController>().transform.position) >= GetComponentInParent<GunController>().GetWeaponItemsSO().range)
            {
                gameObject.SetActive(false);
            }


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTape : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private Transform bulletPrefab;// bullet 
    [Header("Amount of Bullet")]
    [SerializeField] private int amount;
    [HideInInspector] public List<GameObject> bulletTapes = new List<GameObject>();
    void Start()
    {
        PoolingObject.Instance.addPool(bulletPrefab.GetComponentInChildren<Bullet>().gameObject, bulletTapes, amount, transform.parent);
    }
 
}

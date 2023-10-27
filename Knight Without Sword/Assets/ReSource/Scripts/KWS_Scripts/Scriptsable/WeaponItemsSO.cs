using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class WeaponItemsSO : ItemSO
{
    [Header("Properties")]
    public float damage;
    public float range;
    public int ammoQuatity;
    public float timeDelay;
    public EquidmentsSO ammoEquipment;
    private void Awake()
    {
        type = ItemsType.Weapon;
    }
}

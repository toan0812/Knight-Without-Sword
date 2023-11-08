using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EquidmentsSO : ItemSO
{
    public int goldPrice;
    public int gemPrice;
    private void Awake()
    {
        type = ItemsType.Equipment;
    }

}

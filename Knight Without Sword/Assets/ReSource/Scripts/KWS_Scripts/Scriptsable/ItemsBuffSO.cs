using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemsBuffSO : ItemSO
{
    private void Awake()
    {
        type = ItemsType.Buff;
    }
}

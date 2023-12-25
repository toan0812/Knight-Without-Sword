using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemSpecialSO : ItemSO
{
    private void Awake()
    {
        type = ItemsType.special;
    }
}

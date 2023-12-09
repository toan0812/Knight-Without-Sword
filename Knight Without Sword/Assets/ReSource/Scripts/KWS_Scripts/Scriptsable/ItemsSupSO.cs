using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemsSupSO : ItemSO
{
    public int goldPrice;
    public int gemPrice;
    private void Awake()
    {
        type = ItemsType.sup;
    }
}

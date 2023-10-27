using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TradingItemSO : ItemSO
{
    private void Awake()
    {
        type = ItemsType.trading;
    }
}

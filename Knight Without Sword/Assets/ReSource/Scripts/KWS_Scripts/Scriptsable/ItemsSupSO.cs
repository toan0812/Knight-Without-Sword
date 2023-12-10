using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ItemsSupSO : ItemSO
{
    public int goldPrice;
    public int gemPrice;
    public SupType supType;
    public upgradePpropertyType upgradeType;
    public ItemOnceTimeType OnceTimeType;
    private void Awake()
    {
        type = ItemsType.sup;
    }
    public enum SupType { byTime, upgradePproperty,onceTime,none }
    public enum upgradePpropertyType { HP,Speed,Damage, reducePproperty,none }
    public enum ItemOnceTimeType { Life,none}
}

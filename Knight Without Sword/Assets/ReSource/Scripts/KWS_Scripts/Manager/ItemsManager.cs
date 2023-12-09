using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : Singleton<ItemsManager>
{
    [Header("List Items")]
    [SerializeField] private List<EquidmentsSO> weaponItems = new List<EquidmentsSO>();
    [Header("List Items Sup")]
    [SerializeField] private List<ItemsSupSO> ItemsSups = new List<ItemsSupSO>();
    public List<EquidmentsSO> GetEquidItemsFromDB()
    {
        foreach (EquidmentsSO weaponItemsSO in weaponItems)
        {
            return weaponItems;
        }
        return null;
    }
    public List<ItemsSupSO> GetItemsSupsFromDB()
    {
        foreach (ItemsSupSO ItemsSupSO in ItemsSups)
        {
            return ItemsSups;
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : Singleton<ItemsManager>
{
    [Header("List Items")]
    [SerializeField] private List<EquidmentsSO> weaponItems = new List<EquidmentsSO>();

    public List<EquidmentsSO> GetEquidItemsFromDB()
    {
        foreach (EquidmentsSO weaponItemsSO in weaponItems)
        {
            return weaponItems;
        }
        return null;
    }
}

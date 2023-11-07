using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    [Header("List Weapon")]
    [SerializeField] private List<WeaponItemsSO> weaponItems = new List<WeaponItemsSO>();
    private PlayerData playerData = new PlayerData();
    private Dictionary<string, int> weaponInfor = new Dictionary<string, int>();
    void Awake()
    {
        weaponInfor.Add(playerData.plasmaAmmo.name, playerData.plasmaAmmo.quatity);
        weaponInfor.Add(playerData.rocketAmmo.name, playerData.rocketAmmo.quatity);
        weaponInfor.Add(playerData.pistolAmmo.name, playerData.pistolAmmo.quatity);
        weaponInfor.Add(playerData.shotgunAmmo.name, playerData.shotgunAmmo.quatity);
    }

    public void UpdateDictionary(ItemSO itemSO, int quatity)
    {
        foreach (KeyValuePair<string, int> kvp in weaponInfor.ToList())
        {
            if (weaponInfor.ContainsKey(itemSO.prefabName) && itemSO.prefabName == kvp.Key)
            {
                var value = kvp.Value;
                value = value + quatity;
                weaponInfor[itemSO.prefabName] = value;
            }
        }
        
    }
    public int GetDataFormDictionary(WeaponItemsSO weaponItemsSO, int quatity)
    {
        foreach (KeyValuePair<string, int> kvp in weaponInfor.ToList())
        {
            if(weaponItemsSO.ammoEquipment.prefabName == kvp.Key)
            {
                quatity = kvp.Value;
                return quatity;
            }
        }      
        return 0;
    }
    public void ReducedAmmoInInventory(WeaponItemsSO weaponItemsSO, int quatityReduced)
    {
        foreach (KeyValuePair<string, int> kvp in weaponInfor.ToList())
        {
            if (weaponItemsSO.ammoEquipment.prefabName == kvp.Key)
            {
                var value = kvp.Value;
                value = value - quatityReduced;
                weaponInfor[weaponItemsSO.ammoEquipment.prefabName] = value;
            }
        }
    }    

}

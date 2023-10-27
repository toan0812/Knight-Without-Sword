using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItems : MonoBehaviour
{
    [SerializeField] private Dictionary<ItemSO, int> ItemsList = new Dictionary<ItemSO, int>();
    [SerializeField] private GameObject commandText;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform transformParent;
    private List<GameObject> commandTextList = new List<GameObject>();
    private int count = 10;
    private PlayerData playerData= new PlayerData();
    private void Start()
    {
        PoolingObject.Instance.addPool(commandText, commandTextList, count, transformParent);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out ItemsPickUp items))
        {
            AddItems(items.GetItemSO());
            collision.gameObject.SetActive(false);
            if (!ItemsList.ContainsKey(items.GetItemSO()))
            {
                ItemsList.Add(items.GetItemSO(), items.GetItemSO().count);
            }
            else
            {
                ItemsList[items.GetItemSO()] += items.GetItemSO().count;
            }
            SpawnComandText(items.GetItemSO());
            //UIManager.Instance.AddItemsUI.ChangeImageItem(ItemsList);
            
        }
    }

    private void AddItems(ItemSO itemSO)
    {
        Debug.Log(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName + itemSO.count);
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.trading)
        {
            playerData.gold += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateGoldText(playerData.gold);
        }  
         if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == playerData.rocketAmmo.name)
        {
            playerData.rocketAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdaterocketText(playerData.rocketAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, playerData.rocketAmmo.quatity);
        }
         if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == playerData.pistolAmmo.name)
        {
            playerData.pistolAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdatePistolammoText(playerData.pistolAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, playerData.pistolAmmo.quatity);
         
        }
         if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == playerData.plasmaAmmo.name)
        {
            playerData.plasmaAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateplasmaText(playerData.plasmaAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, playerData.plasmaAmmo.quatity);
        }
         if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == playerData.shotgunAmmo.name)
        {
            playerData.shotgunAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateshotgunText(playerData.shotgunAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, playerData.shotgunAmmo.quatity);
        }
       
    }
    private void SpawnComandText(ItemSO itemsSO)
    {
        GameObject plusCommand = PoolingObject.Instance.GetPoolingobj(commandTextList);
        plusCommand.transform.position = spawnTransform.position;
        plusCommand.SetActive(true);
        plusCommand.GetComponent<AddItemsUI>().ChangeImageItem(itemsSO);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GetItems : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] PlayerDamageReciver playerDamageReciver;
    private Dictionary<ItemSO, int> ItemsList = new Dictionary<ItemSO, int>();
    [Header("UI Prefab")]
    [SerializeField] private GameObject commandText;
    [SerializeField] private Transform spawnTransform;
    [SerializeField] private Transform transformParent;
    private List<GameObject> commandTextList = new List<GameObject>();
    private int count = 10;

    private void Start()
    {
       
        PoolingObject.Instance.addPool(commandText, commandTextList, count, transformParent);
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("MenuScene");
        }
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
            
        }
    }

    public void AddItems(ItemSO itemSO)
    {
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.trading && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == "Gold")
        {
            DataManager.Instance.PlayerData.gold += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateGoldText(DataManager.Instance.PlayerData.gold);
            DataManager.Instance.SaveData();
        } 
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Buff && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == "Medical")
        {
            playerDamageReciver.BuffHealth(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().buffValue);
        } 
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.trading && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == "Gem")
        {
            DataManager.Instance.PlayerData.gem += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateGemText(DataManager.Instance.PlayerData.gem);
            DataManager.Instance.SaveData();
        }  
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == DataManager.Instance.PlayerData.rocketAmmo.name)
        {
            DataManager.Instance.PlayerData.rocketAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdaterocketText(DataManager.Instance.PlayerData.rocketAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, DataManager.Instance.PlayerData.rocketAmmo.quatity);
        }
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == DataManager.Instance.PlayerData.pistolAmmo.name)
        {
            DataManager.Instance.PlayerData.pistolAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdatePistolammoText(DataManager.Instance.PlayerData.pistolAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, DataManager.Instance.PlayerData.pistolAmmo.quatity);
         
        }
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == DataManager.Instance.PlayerData.plasmaAmmo.name)
        {
            DataManager.Instance.PlayerData.plasmaAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateplasmaText(DataManager.Instance.PlayerData.plasmaAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, DataManager.Instance.PlayerData.plasmaAmmo.quatity);
        }
        if (itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().type == ItemsType.Equipment && itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO().prefabName == DataManager.Instance.PlayerData.shotgunAmmo.name)
        {
            DataManager.Instance.PlayerData.shotgunAmmo.quatity += itemSO.count;
            UIManager.Instance.HeaderUI.UpdateshotgunText(DataManager.Instance.PlayerData.shotgunAmmo.quatity);
            WeaponManager.Instance.UpdateDictionary(itemSO.prefab.GetComponent<ItemsPickUp>().GetItemSO(), itemSO.count);
            UIManager.Instance.GunHoderUI.UpdateAmmoHolder(itemSO, DataManager.Instance.PlayerData.shotgunAmmo.quatity);
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

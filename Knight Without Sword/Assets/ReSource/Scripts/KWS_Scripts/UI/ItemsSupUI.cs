using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ItemsSupUI : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject iconItemBuffPrefab;
    private List<ItemsSupSO> listItem = new List<ItemsSupSO>();
    void Start()
    {
        iconItemBuffPrefab.SetActive(false);
    }
    public void SpawnIcon(ItemsSupSO iconSprite)
    {
        if(!CheckItemInList(iconSprite))
        {
            var item = Instantiate(iconItemBuffPrefab, transform);
            item.GetComponent<Image>().sprite = iconSprite.prefabImage;
            item.GetComponent<IconItemBuffSO>().ItemsSupSO = iconSprite;
            item.SetActive(true);
            listItem.Add(item.GetComponent<IconItemBuffSO>().ItemsSupSO);
        }

    }
    public bool CheckItemInList(ItemsSupSO item)
    {
        foreach (ItemsSupSO item1 in listItem)
        {
            if (listItem.Contains(item))
            {
                return true;
            }
        }
        return false;
    }
}

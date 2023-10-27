using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawmManager : Singleton<CollectableSpawmManager>
{
    public CollectableItem[] ListItems;
    int[] accumulatedPercentages;
    private void Awake()
    {
        if (ListItems != null && ListItems.Length > 0) CalculateAccumulatedPercentages();
    }

    // tính prefix sum 
    void CalculateAccumulatedPercentages()
    {
        accumulatedPercentages = new int[ListItems.Length];
        accumulatedPercentages[0] = ListItems[0].Rate;

        for (int index = 1; index < ListItems.Length; index++)
        {
            accumulatedPercentages[index] = accumulatedPercentages[index - 1] + ListItems[index].Rate;
        }
    }
    public Transform Spawn()
    {
        int totalPercentage = accumulatedPercentages[accumulatedPercentages.Length - 1];
        if (totalPercentage <= 0)
        {
            Debug.Log("all item has rate is 0");
            return null;
        }
        int randomValue = Random.Range(1, totalPercentage + 1);
        int itemIndex = BinarySearch(randomValue);
        if (itemIndex != -1)
        {
            Transform gameObjectTrans = ListItems[itemIndex].prefab.prefab;
            return gameObjectTrans;
        }
        return null;
    }
    int BinarySearch(int value)
    {
        int left = 0;
        int right = accumulatedPercentages.Length - 1;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (accumulatedPercentages[mid] < value) left = mid + 1;
            else if (accumulatedPercentages[mid] >= value) right = mid;
        }
        return accumulatedPercentages[left] >= value ? left : -1;
    }
}
[System.Serializable]
public class CollectableItem
{
    [Range(0, 100)]
    public int Rate;
    public ItemSO prefab;
}



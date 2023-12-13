using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemsSupSO;

public class IconItemBuffSO : MonoBehaviour, IBuffable
{
    [Header("SO")]
    [SerializeField] public ItemsSupSO ItemsSupSO;
    [Header("Component")]
    [SerializeField] private PlayerDamageReciver playerDamageReciver;
    [SerializeField] private Player player;
    [SerializeField] private ItemsSupUI itemsSupUI;
    [Header("Buff By Time")]
    [SerializeField] private float timeDelay;
    private float time;
    private bool canBuff = false;
    private void OnEnable()
    {
        if(ItemsSupSO!= null)
            ApplyBuff(ItemsSupSO);
    }
    private void Start()
    {
        time = timeDelay;
    }

    private void Update()
    {
        if (canBuff)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                playerDamageReciver.BuffHealth(ItemsSupSO.buffValue);
                time = timeDelay;
            }
        }
       
    }
    public void ApplyBuff(ItemsSupSO itemsSupSO)
    {
        if (itemsSupSO.supType == SupType.byTime)
        {
            canBuff = true;
        }
        if(itemsSupSO.supType == SupType.upgradePproperty)
        {
            if(itemsSupSO.upgradeType == upgradePpropertyType.Speed)
            {
                // Upgrade Speed
                Debug.Log("Buff Speed");
                player.UpGradeSpeed(itemsSupSO.buffValue);
            }  
            if(itemsSupSO.upgradeType == upgradePpropertyType.reducePproperty)
            {
                // Upgrade Reduce time Dash
                Debug.Log("reduce time");
                player.ReduceTimeDash(itemsSupSO.buffValue);
            }  
            if(itemsSupSO.upgradeType == upgradePpropertyType.Damage)
            {
                // Upgrade Basic Damage
            }
            if(itemsSupSO.upgradeType == upgradePpropertyType.HP)
            {
                // Upgrade Hp
            }
            
        }
        if(itemsSupSO.supType == SupType.onceTime)
        {
            Debug.Log("add Time Dead");
            playerDamageReciver.AddTimeDead(itemsSupSO.buffValue);
        }
    }

}

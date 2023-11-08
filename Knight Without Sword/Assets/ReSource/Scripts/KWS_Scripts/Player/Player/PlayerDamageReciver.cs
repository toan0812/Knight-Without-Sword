using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    //[SerializeField] private HealthBar healthBar;
    protected override void Start()
    {
        base.Start();
        maxHealth = DataManager.Instance.PlayerData.health;
        //healthBar.SetMaxHealth(maxHealth);
        //InventoryManager.Instance.OnUseItems += Instance_OnUseItems;
    }
    //private void Update()
    //{
    //    if(currentHealth<=0)
    //    {
    //        //dead
    //    }
    //}
    //private void Instance_OnUseItems(object sender, InventoryManager.OnUseItemsEventArg e)
    //{
    //    if (e.itemsSO.usesType == UsesType.BuffHp)
    //    {
    //        Onupgrade(e.itemsSO.buffValue);
    //    }
    //}
    //private void Update()
    //{
    //    healthBar.SetHealth(currentHealth);
    //}



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    [SerializeField] private SliderUI healthBar;
    protected override void Start()
    {
        base.Start();
        maxHealth = DataManager.Instance.PlayerData.health;
        healthBar.SetSliderMaxValue((int)maxHealth);
        //InventoryManager.Instance.OnUseItems += Instance_OnUseItems;
    }
    //private void Update()
    //{
    //    if (currentHealth <= 0)
    //    {
    //        //dead
    //        Debug.Log("dead");
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

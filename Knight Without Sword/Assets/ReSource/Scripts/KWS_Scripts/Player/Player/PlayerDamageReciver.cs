using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    [SerializeField] private SliderUI healthBar;
    [SerializeField] private int timeDead = 0;
    private void Awake()
    {
        maxHealth = DataManager.Instance.PlayerData.health;
    }
    protected override void Start()
    {
        base.Start();
        healthBar.SetSliderMaxValue((int)maxHealth);
    }
    private void Update()
    {
        healthBar.SetSliderValue((int)currentHealth);
        if (currentHealth <= 0 && timeDead<0)
        {
            //dead
            Debug.Log("dead");
        }
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void BuffHealth(int value)
    {
        Debug.Log("Buff health +" + value);
        currentHealth += value;
    }
    public void AddTimeDead(int value)
    {
        Debug.Log("AddTimeDead +" + value);
        timeDead += value;
    }


}

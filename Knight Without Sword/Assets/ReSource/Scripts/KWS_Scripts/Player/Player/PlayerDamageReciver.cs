using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReciver
{
    [SerializeField] private PauseUI pauseUI;
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
            StartCoroutine(Playerdead());
            Debug.Log("dead");
        }
        if (currentHealth <= 0 && timeDead > 0)
        {
            // revise
            currentHealth = maxHealth;
        }
        if (currentHealth >= maxHealth)
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

    IEnumerator Playerdead()
    {
        Player.Instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        pauseUI.gameObject.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReciver : MonoBehaviour, IDamageable
{
    [Header("HP")]
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;
    private float previousValue;
    private bool IsDead;
    private bool takeDamage;
    [Header("Spawn Text ")]
    [SerializeField] protected GameObject commandDamageUI;
    [SerializeField] protected Transform transformParent;
    [SerializeField] protected Transform spawnTransform;
    private List<GameObject> commandDamageUIList = new List<GameObject>();

    [Header("Effects")]
    [SerializeField] private GameObject bloodEffect;
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        previousValue = currentHealth;
        PoolingObject.Instance.addPool(commandDamageUI, commandDamageUIList, 10, transformParent);
    }
    void SpawnComandDamageUI(int damage)
    {
        GameObject damageUI = PoolingObject.Instance.GetPoolingobj(commandDamageUIList);
        damageUI.SetActive(true);
        damageUI.transform.position = spawnTransform.position;
        damageUI.GetComponent<CommandTextUI>().ChangeCommandText(damage);
    }
    void IDamageable.TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(ChangeColor());
        if (currentHealth <= 0)
        {
            StopCoroutine(ChangeColor());
            IsDead = true;
            currentHealth = 0;
            
            var effect = Instantiate(bloodEffect);
            effect.transform.position = transform.position;
            
        }
        if (currentHealth != previousValue)
        {
            SpawnComandDamageUI(damage);
            previousValue = currentHealth;
        }
        else
        {
            IsDead = false;
        }
        
    }
    IEnumerator ChangeColor()
    {
       GetComponentInChildren<SpriteRenderer>().material.color = Color.red;
       yield return new WaitForSeconds(0.2f);
        GetComponentInChildren<SpriteRenderer>().material.color = Color.white;
       yield return new WaitForSeconds(0.2f);
    }
    public bool Dead()
    {
        return IsDead;
    }
    public bool DamageRecive()
    {
        return takeDamage;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDameReciver : MonoBehaviour,IDamageable
{
    [Header("Spawn Text ")]
    [SerializeField] protected GameObject commandDamageUI;
    [SerializeField] protected Transform transformParent;
    [SerializeField] protected Transform spawnTransform;
    private List<GameObject> commandDamageUIList = new List<GameObject>();
    protected virtual void Start()
    {
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
        StartCoroutine(ChangeColor());
        SpawnComandDamageUI(damage);
    }
    IEnumerator ChangeColor()
    {
        GetComponentInChildren<SpriteRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        GetComponentInChildren<SpriteRenderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
    }
}

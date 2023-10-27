using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : DamageReciver
{
    [SerializeField] private List<GameObject> listItems = new List<GameObject>();
    protected override void Start()
    {
        base.Start();
        listItems.Add(CollectableSpawmManager.Instance.Spawn().gameObject);
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            SpawnItems();
            gameObject.SetActive(false);
        }
    }
    private void SpawnItems()
    {
        foreach (GameObject gameObject in listItems)
        {
            var objectSpawmed = Instantiate(gameObject);
            objectSpawmed.transform.position = transform.position;
            objectSpawmed.SetActive(true);
        }
    }

}

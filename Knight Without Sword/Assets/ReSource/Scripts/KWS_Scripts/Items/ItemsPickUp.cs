using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickUp : MonoBehaviour
{
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;
    void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }
    IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 starPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new Vector2(randomX, randomY);
        float timePassed = 0f;
        while(timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heightT = animationCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f,heightY,heightT);

            transform.position = Vector2.Lerp(starPoint,endPoint,linearT) + new Vector2(0,height);
            yield return null;
        }
    }

    public ItemSO GetItemSO()
    {
        return itemSO;
    }
}

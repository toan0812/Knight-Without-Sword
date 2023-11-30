using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObsKnockback : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;
    private void OnEnable()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }
    IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 starPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-1f, .5f);
        float randomY = transform.position.y + Random.Range(-1f, .5f);

        Vector2 endPoint = new Vector2(randomX, randomY);
        float timePassed = 0f;
        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heightT = animationCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(starPoint, endPoint, linearT) + new Vector2(0, height);;
            yield return null;
        }
    }
}

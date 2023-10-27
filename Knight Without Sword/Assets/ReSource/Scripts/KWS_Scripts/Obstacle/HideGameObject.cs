using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameObject : MonoBehaviour
{
    [SerializeField] private float timeWait = 1f;
    private void OnEnable()
    {
        StartCoroutine(HideObject());
    }
    IEnumerator HideObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeWait);
            gameObject.SetActive(false);
        }

    }
}

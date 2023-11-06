using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{

    [Header("Selected")]
    [SerializeField] private GameObject selected;
    [Header("LayerMask")]
    [SerializeField] private LayerMask playerLayer;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        selected.SetActive(false);
        spriteRenderer =GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DetivedPlayer();
    }

    protected virtual void DetivedPlayer()
    {
        float interactDistance = 2.5f;
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, interactDistance, playerLayer);
        if (collider2D)
        {
            selected.SetActive(true);
        }
        else
        {
            selected.SetActive(false);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            spriteRenderer.color = new Color(1f, 1f, 1f,0.6f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}

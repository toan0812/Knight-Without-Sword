using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : Controllers
{

    [Header("Selected")]
    [SerializeField] private GameObject selected;
    [Header("LayerMask")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private ShopUI shopUI;
    private SpriteRenderer spriteRenderer;
    //public TypeInteract tpyeInteract;
    void Start()
    {
        selected.SetActive(false);
        spriteRenderer =GetComponent<SpriteRenderer>();
        GameInput.Instance.OnInteract += Instance_OnInteract;
    }

    private void Instance_OnInteract(object sender, System.EventArgs e)
    {
        if (Player.Instance.ActiveInteract())
        {
            shopUI.ActiveHolder();
        }
    }
    void Update()
    {
        DetivedPlayer();
    }

    protected virtual void DetivedPlayer()
    {
        if (Player.Instance.ActiveInteract())
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

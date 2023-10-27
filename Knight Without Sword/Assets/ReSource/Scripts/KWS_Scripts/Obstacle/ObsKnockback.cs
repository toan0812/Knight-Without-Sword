using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float forceBack;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        var direction = new Vector2(-offset.x, offset.y);
        GetComponent<Rigidbody2D>().AddForce(direction * 500);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    protected void FlyIntoPlayer(float radius,LayerMask playerLayer)
    {
        if(Physics2D.OverlapCircle(transform.position,radius, playerLayer))
        {
            transform.position = Vector2.MoveTowards(transform.position,Player.Instance.transform.position,10*Time.fixedDeltaTime);
        }
    }
}

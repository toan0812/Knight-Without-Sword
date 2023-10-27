using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public virtual void DealDamage(int damage, Collider2D collider2D, float randiusExplosion, LayerMask layerAffect)
    {
        collider2D = Physics2D.OverlapCircle(transform.position, randiusExplosion, layerAffect);
        if (collider2D != null && collider2D.TryGetComponent(out IDamageable damageable) && randiusExplosion>0)
        {
            damageable.TakeDamage(damage);
        }
    }
}

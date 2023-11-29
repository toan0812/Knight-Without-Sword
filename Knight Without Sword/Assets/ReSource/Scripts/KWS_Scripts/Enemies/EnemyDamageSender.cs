using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable iDamageable) && collision.collider.TryGetComponent(out Player player))
        {
            iDamageable = collision.collider.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.TakeDamage(SendDamage(damage));
                ShakeCamera.Instance.CameraShaking();
            }
        }
    }

    public int GetDamage()
    { return damage; }

    protected override int SendDamage(int damage)
    {
        return damage;
    }
}

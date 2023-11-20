using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable iDamageable))
        {
            Debug.Log("Send Damage");
            iDamageable = collision.collider.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.TakeDamage(SendDamage(damage));
                ShakeCamera.Instance.CameraShaking();
            }
        }
    }

    protected override int SendDamage(int damage)
    {
        return damage;
    }
}

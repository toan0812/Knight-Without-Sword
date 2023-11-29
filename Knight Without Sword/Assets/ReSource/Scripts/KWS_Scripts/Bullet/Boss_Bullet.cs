using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : ClassicBullet
{
    protected override void Start()
    {
        base.Start();
    }
    void Update()
    {
        BulletMoving();

    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable iDamageable) && Physics2D.OverlapCircle(transform.position, 0.2f, activeEffect))
        {
            iDamageable = collision.collider.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.TakeDamage(GetComponentInParent<EnemyDamageSender>().GetDamage());
                SpawnFX(collision.collider.transform, collision.collider);
                gameObject.SetActive(false);
            }
        }
        else if (Physics2D.OverlapCircle(transform.position, 0.2f, activeEffect))
        {
            SpawnFX(gameObject.transform, collision.collider);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        BulletMoving();
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(GameObject.FindObjectOfType<Enemy>().transform.position.normalized));
        
    }
    protected override void BulletMoving()
    {
        if (transform.parent == null) return;
        Debug.Log(transform.parent.GetComponentInParent<Enemy>());
        rb.velocity = transform.parent.GetComponentInParent<Enemy>().GetTargetTransform().normalized * bulletSpeed * Time.deltaTime;
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
    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}

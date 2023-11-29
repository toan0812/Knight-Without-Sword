using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class Bullet : MonoBehaviour
{
    [Header("Bullet Prperties")]
    [SerializeField] protected float bulletSpeed;
    [Header(("Effect"))]
    [SerializeField] Transform bulletEffect;
    [SerializeField] protected LayerMask activeEffect;
    [SerializeField] protected LayerMask layerAffect;
    [SerializeField] protected float radiusEffect;
    [Header("Damage")]
    protected int damage;
    // Pooling 
    private List<GameObject> effectList = new List<GameObject>();
    private GunController gunController;
    protected virtual void Start()
    {
        PoolingObject.Instance.addPool(bulletEffect.gameObject, effectList, 10, transform.parent);
        gunController = GetComponentInParent<GunController>();
    }
    public int GetDamage()
    {
        damage = (int)gunController.GetWeaponItemsSO().damage;
        return damage;
    }
    protected abstract void BulletMoving();
    protected virtual void SpawnFX(Transform positionCollider, Collider2D colliderAffect)
    {
        var effect = PoolingObject.Instance.GetPoolingobj(effectList);
        effect.transform.position = positionCollider.position;
        effect.SetActive(colliderAffect);
        effect.GetComponent<Explosion>().DealDamage(damage, colliderAffect, radiusEffect, layerAffect);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDamageable iDamageable) && Physics2D.OverlapCircle(transform.position, 0.2f, activeEffect))
        {
            iDamageable = collision.collider.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.TakeDamage(GetDamage());
                ShakeCamera.Instance.CameraShaking();
                SpawnFX(collision.collider.transform, collision.collider);
                gameObject.SetActive(false);
                //Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                //Vector2 knockback = knockbackDirection * knockBackForce;
                //iDamageable.OnHit(knockback);
            }
        }
        else if(Physics2D.OverlapCircle(transform.position, 0.2f, activeEffect))
        {
            SpawnFX(gameObject.transform, collision.collider);
            gameObject.SetActive(false);
        }
    }
    // Parent direction
    protected virtual Vector2 GetParentDirection(Vector3 dir)
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) - dir;
    }
}

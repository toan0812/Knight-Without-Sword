using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1ShootAction : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private EnemyDamageSender _enemyDamageSender;
    [SerializeField] private Boss_1Controller boss_1Controller;
    [Header("Prefab Attack 1")]
    [SerializeField] private Transform bulletPrefab;
    [Header("Prefab Attack 2")]
    [SerializeField] private Transform bulletPrefab2;
    [SerializeField] private Transform bulletPrefab2Pos;
    // List
    private List<GameObject> bullet1Tapes = new List<GameObject>();
    private List<GameObject> bullet2Tapes = new List<GameObject>();
    [Header("Prefab Holder")]
    [SerializeField] private Transform holder;
    [Header("bullet Spread Attack 1")]
    [SerializeField] protected int numberBullet;
    [Range(0, 360)]
    [SerializeField] private float startAngle, endAngle;

    [Header("Attack 3")]
    [SerializeField] Transform lazerOrigin;
    [SerializeField] LayerMask LayerMask;
    [SerializeField] GameObject endVFX;
    [SerializeField] GameObject startVFX;
    [SerializeField] private Transform shootPosAttack3;
    [SerializeField] private int attackRange;
    [SerializeField]LineRenderer lineRendererCanAffect;
    [SerializeField]LineRenderer lineRendererStart;
    [SerializeField]private List<ParticleSystem> particles = new List<ParticleSystem>();
    float timer = 0;

    private void Start()
    {
        PoolingObject.Instance.addPool(bulletPrefab.GetComponentInChildren<Bullet>().gameObject, bullet1Tapes, 40, holder);
        PoolingObject.Instance.addPool(bulletPrefab2.GetComponentInChildren<Bullet>().gameObject, bullet2Tapes, 10, holder);

        //FillList();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    //////////// SHOOTING //////////
    /// <summary>
    /// SHOOT ATTACK1
    /// </summary>
    public void Attack_1Shooting()
    {
        float angleStep = (endAngle - startAngle) / numberBullet;
        float angle = startAngle;
        for (int i = 0; i < numberBullet; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            Vector3 bulMoveDir = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveDir - transform.position).normalized;
            GameObject Bullet = PoolingObject.Instance.GetPoolingobj(bullet1Tapes);
            Bullet.transform.position = transform.position;
            Bullet.SetActive(true);
            Bullet.GetComponentInChildren<Boss_Bullet>().SetDirection(bulDir);
            angle += angleStep;
        }
    }

    /// <summary>
    /// SHOOT ATTACK2
    /// </summary>
    public void Attack_2Shooting()
    {
        GameObject Bullet = PoolingObject.Instance.GetPoolingobj(bullet2Tapes);
        Bullet.transform.position = bulletPrefab2Pos.position;
        Bullet.SetActive(true);
    }

    /// <summary>
    /// SHOOT ATTACK3
    /// </summary>
    public void Attack_3Shooting()
    {
        SetActiveLazer();
        lineRendererStart.enabled = false;
        //shootPosAttack3.gameObject.SetActive(false);
        lineRendererCanAffect.SetPosition(0, lazerOrigin.position);
        startVFX.transform.position = lazerOrigin.position;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(shootPosAttack3.position, new Vector3(boss_1Controller.GetTargetTransform().x, boss_1Controller.GetTargetTransform().y - 1f).normalized.normalized, attackRange, LayerMask);
        if (raycastHit2D.collider != null)
        {
            lineRendererCanAffect.SetPosition(1, raycastHit2D.point);
            if (raycastHit2D.collider.TryGetComponent(out IDamageable iDamageable))
            {
                iDamageable = raycastHit2D.collider.GetComponent<IDamageable>();
                if (iDamageable != null && timer <= 0)
                {
                    timer = .5f;
                    iDamageable.TakeDamage(_enemyDamageSender.GetDamage());

                }
            }
        }
        else
        {
            if (timer <= 0)
            {
                timer = .25f;
            }
            lineRendererCanAffect.SetPosition(1, shootPosAttack3.position + (new Vector3(boss_1Controller.GetTargetTransform().x, boss_1Controller.GetTargetTransform().y - 1f) * attackRange));
        }
        endVFX.transform.position = lineRendererCanAffect.GetPosition(1);
    }


    void SetActiveLazer()
    {
        lineRendererCanAffect.enabled = true;
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
    }

    //void FillList()
    //{
    //    for (int i = 0; i < startVFX.transform.childCount; i++)
    //    {
    //        var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
    //        if (ps != null)
    //        {
    //            particles.Add(ps);
    //        }
    //    }

    //    for (int i = 0; i < endVFX.transform.childCount; i++)
    //    {
    //        var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
    //        if (ps != null)
    //        {
    //            particles.Add(ps);
    //        }
    //    }
    //}
    public void EndActiveLazer()
    {
        lineRendererCanAffect.enabled = false;
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Stop();
        }
    }

    public void SetActiveSpawnPos()
    {
        shootPosAttack3.gameObject.SetActive(true);
        lineRendererStart.enabled = true;
        lineRendererStart.SetPosition(0, lazerOrigin.position);
        RaycastHit2D raycastHit2D = Physics2D.Raycast(shootPosAttack3.position, new Vector3(boss_1Controller.GetTargetTransform().x, boss_1Controller.GetTargetTransform().y - 1f).normalized, attackRange, LayerMask);
        if (raycastHit2D.collider != null)
        {
            lineRendererStart.SetPosition(1, raycastHit2D.point);
        }
        else
            lineRendererStart.SetPosition(1, shootPosAttack3.position + (boss_1Controller.GetTargetTransform() * attackRange));

    }
}

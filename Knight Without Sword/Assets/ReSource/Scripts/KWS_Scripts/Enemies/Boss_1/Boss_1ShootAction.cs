using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1ShootAction : MonoBehaviour
{
    [Header("Prefab Attack 1")]
    [SerializeField] private Transform bulletPrefab;
    [Header("Prefab Attack 2")]
    [SerializeField] private Transform bulletPrefab2;
    [SerializeField] private Transform bulletPrefab2Pos;
    private List<GameObject> bullet1Tapes = new List<GameObject>();
    private List<GameObject> bullet2Tapes = new List<GameObject>();
    [Header("Prefab Holder")]
    [SerializeField] private Transform holder;
    [Header("bullet Spread Attack 1")]
    [SerializeField] protected int numberBullet;
    [Range(0, 360)]
    [SerializeField] private float startAngle, endAngle;
    private void Start()
    {
        PoolingObject.Instance.addPool(bulletPrefab.GetComponentInChildren<Bullet>().gameObject, bullet1Tapes, 40, holder);
        PoolingObject.Instance.addPool(bulletPrefab2.GetComponentInChildren<Bullet>().gameObject, bullet2Tapes, 10, holder);
    }

    //////////// SHOOTING //////////
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
    public void Attack_2Shooting()
    {
        GameObject Bullet = PoolingObject.Instance.GetPoolingobj(bullet2Tapes);
        Bullet.transform.position = bulletPrefab2Pos.position;
        Bullet.SetActive(true);
    }
    public void Attack_3Shooting()
    {

    }
}

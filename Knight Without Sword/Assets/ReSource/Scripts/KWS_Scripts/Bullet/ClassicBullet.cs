using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClassicBullet : Bullet
{
    private Vector2 dir;
    private void OnEnable()
    {
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(GetParentDirection(GameObject.FindObjectOfType<Player>().transform.position).normalized));
    }
    private void Update()
    {
        BulletMoving();
    }
    protected override void BulletMoving()
    {
        /*if (transform.parent == null) return;*/
        //GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed * GetParentDirection(GameObject.FindObjectOfType<Player>().transform.position).normalized;
        transform.Translate(dir* bulletSpeed * Time.deltaTime);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
    public void SetDirection(Vector2 dir)
    {
        this.dir = dir;
    }
    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n<0) n += 360;
        return n;
    }
}

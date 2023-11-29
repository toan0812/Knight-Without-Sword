using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] protected Transform target;
    protected NavMeshAgent agent;
    [Header("Icons")]
    [SerializeField] GameObject cautionIcon;
    private int timeActive =1;
    protected bool faceRight = true;
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindAnyObjectByType<Player>().transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    public virtual void EnemyMove()
    {
        agent.SetDestination(target.position);
    }
    protected virtual void EnemyAttack()
    {
    }
    protected bool TargetOnAttackZone(Transform target,float ZoneFollowTarget)
    {
        if (Vector2.Distance(target.transform.position, transform.position) <= ZoneFollowTarget)
        {
            if(timeActive>0)
            {
                cautionIcon.SetActive(true);
                timeActive--;
            }
            
            return true;
        }
        return false;
    }

    protected virtual void LookAtTarget() {

        Vector3 movedir = new Vector3(-transform.position.x + target.transform.position.x, -transform.position.y + +target.transform.position.y).normalized;
        if (faceRight && movedir.x < 0)
        {
            FaceFlip();
            faceRight = false;
        }
        if (!faceRight && movedir.x > 0)
        {
            FaceFlip();
            faceRight = true;
        };
    }

    private void FaceFlip()
    {
        Vector3 Scaler = transform.GetChild(0).localScale;
        Scaler.x = Scaler.x * -1;
        transform.GetChild(0).localScale = Scaler;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] protected Transform target;
    protected NavMeshAgent agent;
    [Header("Enemy information")]
    [SerializeField]protected int damage;
    [Header("Icons")]
    [SerializeField] GameObject cautionIcon;
    private int timeActive =1;
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    protected virtual void EnemyMove()
    {
        agent.SetDestination(target.position);
    }
    protected virtual void EnemyAttack()
    {
    }
    protected bool TargetOnAttackZone(Transform target,float radiusZone)
    {
        if (Vector2.Distance(target.transform.position, transform.position) <= radiusZone)
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

}

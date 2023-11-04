using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected Transform target;
    protected NavMeshAgent agent;

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
    protected abstract void TargetOnAttackZone(float radiusZone);

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Coomponents")]
    [SerializeField] private EnemyDamageReciver enemyDamageReciver;
    [SerializeField] private Enemy_WideRange enemyWideRange;
    [SerializeField] private Animator animator;
    private const string Dead = "dead";
    private const string Idle = "idle";
    private const string Run = "run";
    private const string Attack = "attack";
    void Update()
    {
        animator.SetBool(Run, enemyWideRange.IsRun());
        animator.SetBool(Idle, enemyWideRange.IsIdle());
        animator.SetBool(Attack, enemyWideRange.IsAttack());
        animator.SetBool(Dead, enemyDamageReciver.Dead());
    }
}

